using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EIReHex
{
    public partial class MainForm : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        public Configuration Config = new Configuration();
        private byte[] ExeBytes;
        private byte[] GameSpeeds = new byte[] { 0x37, 0x1B, 0x14, 0x05 };
        private const string LoadingText = "LoadingText";
        private const string ApplyingText = "ApplyingText";
        private const string DoneText = "DoneText";
        private const string FileNotFound = "FileNotFound";
        private const string AddonDllMsgCaption = "AddonDllMsgCaption";
        private const string AddonDllMsgText = "AddonDllMsgText";
        private const string AddonDllAlreadyFixed = "AddonDllAlreadyFixed";
        private const string AddonDllError = "AddonDllError";
        private string ExeSettings;
        private Dictionary<string, string> StringsResEn;
        private Dictionary<string, string> StringsResRu;
        private Dictionary<string, string> DetailsResEn;
        private Dictionary<string, string> DetailsResRu;

        public MainForm()
        {
            InitializeComponent();
            LoadResources();
            Config.Load();
            ApplyCurrentLanguage();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            GitHubLink.Cursor = new Cursor(LoadCursor(IntPtr.Zero, 32649));
            DetailsPanel.Height = LoadingPanel.Top - DetailsPanel.Top;
            DetailsPanel.Width = ClientSize.Width;
            DetailsPanel.BringToFront();

            PopulateForm();
            AssignControlsEvents(Controls);
        }

        private void ApplyCurrentLanguage()
        {
            var strings = Config.Language.Same("EN") ? StringsResEn : StringsResRu;
            var details = Config.Language.Same("EN") ? DetailsResEn : DetailsResRu;

            foreach (Control c in GetAllControls(this))
            {
                if (strings.ContainsKey(c.Name))
                {
                    if (c.GetType() == typeof(GroupBox))
                    {
                        c.Text = " " + strings[c.Name];
                    }
                    else
                    {
                        c.Text = strings[c.Name];
                    }
                }

                if (details.ContainsKey(c.Name))
                {
                    c.AccessibleDescription = details[c.Name];
                }
            }
        }

        private void LoadResources()
        {
            StringsResEn = typeof(StringsEn).GetTypeInfo()
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(string))
                .ToDictionary(p => p.Name, p => (string)p.GetValue(null));

            StringsResRu = typeof(StringsRu).GetTypeInfo()
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(string))
                .ToDictionary(p => p.Name, p => (string)p.GetValue(null));

            DetailsResEn = typeof(DetailsEn).GetTypeInfo()
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(string))
                .ToDictionary(p => p.Name, p => (string)p.GetValue(null));

            DetailsResRu = typeof(DetailsRu).GetTypeInfo()
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(string))
                .ToDictionary(p => p.Name, p => (string)p.GetValue(null));
        }

        private string GetResourceString(string name)
        {
            var strings = Config.Language.Same("EN") ? StringsResEn : StringsResRu;
            
            if (strings.TryGetValue(name, out string value))
            {
                return value;
            }

            return string.Empty;
        }

        private void SelectExeButton_Click(object sender, EventArgs e)
        {
            SelectGameExeDialog.InitialDirectory = string.IsNullOrWhiteSpace(Config.GameExePath)
                ? Path.GetDirectoryName(Application.ExecutablePath)
                : Path.GetDirectoryName(Config.GameExePath);

            if (SelectGameExeDialog.ShowDialog() == DialogResult.OK)
            {
                if (SelectGameExeDialog.FileName.ToLower().EndsWith("\\addon.dll"))
                {
                    if (MessageBox.Show(GetResourceString(AddonDllMsgText), GetResourceString(AddonDllMsgCaption), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        TreatAddonDll(SelectGameExeDialog.FileName);
                    }
                    
                    return;
                }

                Config.GameExePath = SelectGameExeDialog.FileName;
                GameExePathTextBox.Text = Config.GameExePath;

                Config.Save();
                LoadGameExe(GetResourceString(LoadingText));
            }
        }

        private void PopulateForm()
        {
            GameExePathTextBox.Text = Config.GameExePath;
            BackupCB.Checked = Config.MakeBackup;
            LoadGameExe(GetResourceString(LoadingText));
        }

        private void LoadGameExe(string loadingText)
        {
            ApplyButton.Enabled = false;

            if (!string.IsNullOrWhiteSpace(Config.GameExePath) && File.Exists(Config.GameExePath))
            {
                EnableGroupBoxes(true);
                EnableControls<Control>(false);
                ShowLoading(loadingText);
                Application.DoEvents();

                ExeBytes = File.ReadAllBytes(Config.GameExePath);

                RunAmountDefaultRB.Checked = true;
                RunAmountDefaultRB.Enabled = IsFeatureApplicable(Feature.RunAmountDouble);
                RunAmountDoubleRB.Enabled = RunAmountDefaultRB.Enabled;
                RunAmountDoubleRB.Checked = IsFeatureActive(Feature.RunAmountDouble);

                var runAmountManaBattleEnabled = IsFeatureApplicable(Feature.RunAmountRedirectBattle)
                    && IsFeatureApplicable(Feature.RunAmountLogicBattleOnly);
                var redirectMana = IsFeatureActive(Feature.RunAmountRedirectMana);
                var redirectBattle = IsFeatureActive(Feature.RunAmountRedirectBattle);
                var battleOnly = IsFeatureActive(Feature.RunAmountLogicBattleOnly);
                var battleAndMana = IsFeatureActive(Feature.RunAmountLogicBattleAndMana);

                RunAmountManaRB.Enabled = runAmountManaBattleEnabled;
                RunAmountManaRB.Checked = battleAndMana && (redirectMana || redirectBattle);

                RunAmountBattleCB.Enabled = runAmountManaBattleEnabled;
                RunAmountBattleCB.Checked = redirectBattle && (battleOnly || battleAndMana);

                GameSpeedDefaultRB.Checked = true;
                GameSpeedDefaultRB.Enabled = IsFeatureApplicable(Feature.GameSpeedNormalUI)
                    && IsFeatureApplicable(Feature.GameSpeedNormalHK)
                    && IsFeatureApplicable(Feature.GameSpeedFastUI)
                    && IsFeatureApplicable(Feature.GameSpeedFastHK)
                    && IsFeatureApplicable(Feature.GameSpeedRestore);
                GameSpeedFastRB.Enabled = GameSpeedDefaultRB.Enabled;
                GameSpeedFastRB.Checked = IsFeatureActive(Feature.GameSpeedNormalHK, GameSpeeds[1])
                    && IsFeatureActive(Feature.GameSpeedNormalUI, GameSpeeds[1])
                    && IsFeatureActive(Feature.GameSpeedFastHK, GameSpeeds[2])
                    && !IsFeatureActive(Feature.GameSpeedFastUI, GameSpeeds[1]);

                GameSpeedSuperCB.Enabled = IsFeatureApplicable(Feature.GameSpeedFastUI);
                GameSpeedSuperCB.Checked = IsFeatureActive(Feature.GameSpeedFastUI, GameSpeeds[3]);

                VillageSpeedDefaultRB.Checked = true;
                VillageSpeedDefaultRB.Enabled = IsFeatureApplicable(Feature.GameSpeedVillageRedirect) && IsFeatureApplicable(Feature.GameSpeedVillageSet1) && IsFeatureApplicable(Feature.GameSpeedVillageDialog1) && IsFeatureApplicable(Feature.GameSpeedVillageDialog2);
                VillageSpeedX2RB.Enabled = VillageSpeedDefaultRB.Enabled;
                VillageSpeedX3RB.Enabled = VillageSpeedDefaultRB.Enabled;
                if (VillageSpeedDefaultRB.Enabled)
                {
                    if (IsFeatureActive(Feature.GameSpeedVillageRedirect))
                    {
                        VillageSpeedX2RB.Checked = IsFeatureActive(Feature.GameSpeedVillageSet2, GameSpeeds[1]);
                        VillageSpeedX3RB.Checked = !VillageSpeedX2RB.Checked && IsFeatureActive(Feature.GameSpeedVillageSet2, GameSpeeds[2]);
                    }
                }

                SpellConstuctorCB.Enabled = IsFeatureApplicable(Feature.SpellConstructor1)
                    && IsFeatureApplicable(Feature.SpellConstructor2)
                    && IsFeatureApplicable(Feature.SpellConstructor3);
                SpellConstuctorCB.Checked = IsFeatureActive(Feature.SpellConstructor1)
                    && IsFeatureActive(Feature.SpellConstructor2)
                    && IsFeatureActive(Feature.SpellConstructor3);

                PartyExpCB.Enabled = IsFeatureApplicable(Feature.PartyExp);
                PartyExpCB.Checked = IsFeatureActive(Feature.PartyExp);

                SecondarySkillsCB.Enabled = IsFeatureApplicable(Feature.SecondarySkillsCost1) && IsFeatureApplicable(Feature.SecondarySkillsCost2);
                SecondarySkillsCB.Checked = IsFeatureActive(Feature.SecondarySkillsCost1) && IsFeatureActive(Feature.SecondarySkillsCost2);

                ExeSettings = GetSettings();
                EnableControls<Control>();
                ShowLoading(null);
                EnableGroupBoxes();
                Setting_Changed(null, null);
            }
            else
            {
                EnableGroupBoxes(false);
                if (!string.IsNullOrWhiteSpace(Config.GameExePath))
                {
                    MessageBox.Show(GetResourceString(FileNotFound) + ":\n" + Config.GameExePath, GetResourceString(FileNotFound), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Config.GameExePath) && ExeBytes.Length > 0)
            {
                ApplyButton.Enabled = false;
                EnableControls<Control>(false);
                ShowLoading(GetResourceString(ApplyingText));
                Application.DoEvents();

                ExeBytes = File.ReadAllBytes(Config.GameExePath);

                if (RunAmountDoubleRB.Checked)
                {
                    ActivateFeature(Feature.RunAmountDouble);
                }
                else
                {
                    DeactivateFeature(Feature.RunAmountDouble);
                }

                DeactivateFeature(Feature.RunAmountRedirectBattle);
                DeactivateFeature(Feature.RunAmountLogicBattleOnly);

                if (RunAmountBattleCB.Checked)
                {
                    ActivateFeature(Feature.RunAmountRedirectBattle);

                    if (RunAmountManaRB.Checked)
                    {
                        ActivateFeature(Feature.RunAmountLogicBattleAndMana);
                    }
                    else
                    {
                        ActivateFeature(Feature.RunAmountLogicBattleOnly);
                    }
                }
                else
                {
                    if (RunAmountManaRB.Checked)
                    {
                        ActivateFeature(Feature.RunAmountRedirectMana);
                        ActivateFeature(Feature.RunAmountLogicBattleAndMana);
                    }
                }

                if (GameSpeedDefaultRB.Checked)
                {
                    ActivateFeature(Feature.GameSpeedNormalHK, GameSpeeds[0]);
                    ActivateFeature(Feature.GameSpeedNormalUI, GameSpeeds[0]);
                    ActivateFeature(Feature.GameSpeedFastHK, GameSpeeds[1]);
                    ActivateFeature(Feature.GameSpeedFastUI, GameSpeeds[1]);
                    ActivateFeature(Feature.GameSpeedRestore, (byte)(256 - GameSpeeds[0] + GameSpeeds[1]), GameSpeeds[0]);
                }
                else if (GameSpeedFastRB.Checked)
                {
                    ActivateFeature(Feature.GameSpeedNormalHK, GameSpeeds[1]);
                    ActivateFeature(Feature.GameSpeedNormalUI, GameSpeeds[1]);
                    ActivateFeature(Feature.GameSpeedFastHK, GameSpeeds[2]);
                    ActivateFeature(Feature.GameSpeedFastUI, GameSpeeds[2]);
                    ActivateFeature(Feature.GameSpeedRestore, (byte)(256 - GameSpeeds[1] + GameSpeeds[2]), GameSpeeds[1]);
                }

                if (GameSpeedSuperCB.Checked)
                {
                    ActivateFeature(Feature.GameSpeedFastUI, GameSpeeds[3]);
                }

                if (VillageSpeedDefaultRB.Checked)
                {
                    DeactivateFeature(Feature.GameSpeedVillageDialog1);
                    DeactivateFeature(Feature.GameSpeedVillageDialog2);
                    DeactivateFeature(Feature.GameSpeedVillageRedirect);
                    DeactivateFeature(Feature.GameSpeedVillageSet1);
                }
                else if (VillageSpeedX2RB.Checked || VillageSpeedX3RB.Checked)
                {
                    var speed = VillageSpeedX2RB.Checked ? GameSpeeds[1] : GameSpeeds[2];
                    
                    // speed setters for dialog begin/end events
                    ActivateFeature(Feature.GameSpeedVillageDialog1);
                    ActivateFeature(Feature.GameSpeedVillageDialog2);
                    ActivateFeature(Feature.GameSpeedVillageDialog3, speed);

                    // speed setter for briefing zone enter event
                    ActivateFeature(Feature.GameSpeedVillageRedirect);
                    ActivateFeature(Feature.GameSpeedVillageSet1);
                    ActivateFeature(Feature.GameSpeedVillageSet2, speed);
                }

                if (SpellConstuctorCB.Checked)
                {
                    ActivateFeature(Feature.SpellConstructor1);
                    ActivateFeature(Feature.SpellConstructor2);
                    ActivateFeature(Feature.SpellConstructor3);
                }
                else
                {
                    DeactivateFeature(Feature.SpellConstructor1);
                    DeactivateFeature(Feature.SpellConstructor2);
                    DeactivateFeature(Feature.SpellConstructor3);
                }

                if (PartyExpCB.Checked)
                {
                    ActivateFeature(Feature.PartyExp);
                }
                else
                {
                    DeactivateFeature(Feature.PartyExp);
                }

                if (SecondarySkillsCB.Checked)
                {
                    ActivateFeature(Feature.SecondarySkillsCost1);
                    ActivateFeature(Feature.SecondarySkillsCost2);
                }
                else
                {
                    DeactivateFeature(Feature.SecondarySkillsCost1);
                    DeactivateFeature(Feature.SecondarySkillsCost2);
                }

                if (Config.MakeBackup)
                {
                    BackupFile(Config.GameExePath);
                }

                File.WriteAllBytes(Config.GameExePath, ExeBytes);
                EnableControls<Control>();
                LoadGameExe(GetResourceString(DoneText));
                Application.DoEvents();
            }
        }

        private string GetSettings()
        {
            var settings = "";
            foreach (Control gb in Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control c in gb.Controls)
                    {
                        if (c is RadioButton rb)
                        {
                            settings += rb.Name + " = " + rb.Checked.ToString() + Environment.NewLine;
                        }
                        else if (c is CheckBox cb)
                        {
                            settings += cb.Name + " = " + cb.Checked.ToString() + Environment.NewLine;
                        }
                    }
                }
            }

            return settings;
        }

        private bool IsFeatureApplicable(string featureName)
        {
            var replacement = Replacements.Single(r => r.Name.Same(featureName));
            
            if (replacement.Substitution == null)
            {
                var result = ExeBytes.FindBytesPattern(replacement.Subject.ParseAsHexPattern()) > 0;
                Application.DoEvents();

                return result;
            }
            else
            {
                var validChunks = new List<string>();
                validChunks.Add(replacement.Subject);

                if (replacement.Offset == 0)
                {
                    validChunks.Add(replacement.Substitution);

                    foreach (var r in Replacements)
                    {
                        if (r.Substitution != null && r.Offset == 0 && r != replacement && r.Subject == replacement.Subject)
                        {
                            validChunks.Add(r.Substitution);
                        }
                    }
                }

                foreach (var chunk in validChunks)
                {
                    if (ExeBytes.FindBytes(chunk.ParseAsHex()) > 0)
                    {
                        Application.DoEvents();
                        return true;
                    }

                    Application.DoEvents();
                }
            }

            return false;
        }

        private bool IsFeatureActive(string featureName, params byte[] values)
        {
            var replacement = Replacements.Single(r => r.Name.Same(featureName));

            if (replacement.Substitution == null)
            {
                if (values?.Length > 0)
                {
                    var subject = replacement.Subject.ParseAsHexPattern();
                    var index = ExeBytes.FindBytesPattern(subject);
                    int valuesIndex = 0;
                    Application.DoEvents();

                    if (index > 0)
                    {
                        for (int i = 0; i < subject.Length; i++)
                        {
                            if (subject[i] == null)
                            {
                                if (ExeBytes[index + i] == values[valuesIndex])
                                {
                                    valuesIndex++;
                                    if (valuesIndex == values.Length)
                                    {
                                        return true;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (replacement.Offset == 0)
                {
                    var result = ExeBytes.FindBytes(replacement.Substitution.ParseAsHex()) > 0;
                    Application.DoEvents();

                    return result;
                }
                else
                {
                    var index = ExeBytes.FindBytes(replacement.Subject.ParseAsHex());
                    Application.DoEvents();

                    if (index > 0)
                    {
                        index += replacement.Offset;
                        var bytes = replacement.Substitution.ParseAsHex();
                        
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            if (ExeBytes[index + i] != bytes[i])
                            {
                                return false;
                            }
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        private bool ActivateFeature(string featureName, params byte[] values)
        {
            var result = false;
            var replacement = Replacements.Single(r => r.Name.Same(featureName));
            
            if (replacement.Substitution == null)
            {
                if (values?.Length > 0)
                {
                    var subject = replacement.Subject.ParseAsHexPattern();
                    var index = ExeBytes.FindBytesPattern(subject);
                    Application.DoEvents();

                    if (index > 0)
                    {
                        int valuesIndex = 0;

                        for (int i = 0; i < subject.Length; i++)
                        {
                            if (subject[i] == null)
                            {
                                ExeBytes[index + i] = values[valuesIndex];
                                valuesIndex++;
                                if (valuesIndex == values.Length)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            else if (replacement.Offset > 0)
            {
                var index = ExeBytes.FindBytes(replacement.Subject.ParseAsHex());
                Application.DoEvents();

                if (index > 0)
                {
                    index += replacement.Offset;
                    var bytes = replacement.Substitution.ParseAsHex();

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        ExeBytes[index + i] = bytes[i];
                    }

                    result = true;
                }
            }
            else
            {
                var chunks = new List<string>();
                chunks.Add(replacement.Subject);

                foreach (var r in Replacements)
                {
                    if (r.Substitution != null && r != replacement && r.Subject == replacement.Subject)
                    {
                        chunks.Add(r.Substitution);
                    }
                }

                foreach (var chunk in chunks)
                {
                    var index = ExeBytes.FindBytes(chunk.ParseAsHex());
                    Application.DoEvents();

                    if (index > 0)
                    {
                        var bytes = replacement.Substitution.ParseAsHex();

                        for (int i = 0; i < bytes.Length; i++)
                        {
                            ExeBytes[index + i] = bytes[i];
                        }

                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private bool DeactivateFeature(string featureName, params byte[] values)
        {
            var result = false;
            var replacement = Replacements.Single(r => r.Name.Same(featureName));
            
            if (replacement.Substitution == null)
            {
                return ActivateFeature(featureName, values);
            }
            else if (replacement.Offset > 0)
            {
                var index = ExeBytes.FindBytes(replacement.Subject.ParseAsHex());
                Application.DoEvents();

                if (index > 0)
                {
                    index += replacement.Offset;

                    for (int i = 0; i < replacement.Offset; i++)
                    {
                        ExeBytes[index + i] = 0;
                    }

                    result = true;
                }
            }
            else
            {
                var chunks = new List<string>();
                chunks.Add(replacement.Substitution);

                foreach (var r in Replacements)
                {
                    if (r.Substitution != null && r != replacement && r.Subject == replacement.Subject)
                    {
                        chunks.Add(r.Substitution);
                    }
                }

                foreach (var chunk in chunks)
                {
                    var index = ExeBytes.FindBytes(chunk.ParseAsHex());
                    Application.DoEvents();

                    if (index > 0)
                    {
                        var subjectBytes = replacement.Subject.ParseAsHex();

                        for (int i = 0; i < subjectBytes.Length; i++)
                        {
                            ExeBytes[index + i] = subjectBytes[i];
                        }

                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

        private void TreatAddonDll(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileBytes = File.ReadAllBytes(filePath);
                var subject =       "D0 8B 00 00 84 C0 75 0E 68 8C B3 04 10 6A 01 E8";
                var substitution =  "D0 8B 00 00 84 C0 EB 0E 68 8C B3 04 10 6A 01 E8";
                var index = fileBytes.FindBytes(subject.ParseAsHex());
                
                if (index > 0)
                {
                    var bytes = substitution.ParseAsHex();

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        fileBytes[index + i] = bytes[i];
                    }

                    BackupFile(filePath);
                    File.WriteAllBytes(filePath, fileBytes);
                }
                else
                {
                    if (fileBytes.FindBytes(substitution.ParseAsHex()) > 0)
                    {
                        MessageBox.Show(GetResourceString(AddonDllAlreadyFixed), Text);
                    }
                    else
                    {
                        MessageBox.Show(GetResourceString(AddonDllError), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BackupFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileName = Path.GetFileName(filePath);
                var dir = Path.GetDirectoryName(filePath);
                var backupNumber = 1;
                string backupPath;

                while (true)
                {
                    backupPath = $"{dir}\\{fileName}.{backupNumber.ToString("00")}.bak";
                    if (!File.Exists(backupPath))
                    {
                        File.Copy(filePath, backupPath);
                        break;
                    }
                    backupNumber++;
                }
            }
        }

        private void ShowLoading(string text)
        {
            if (text != null)
            {
                AnalyzingLabel.Text = text;
                LoadingPanel.Width = ClientSize.Width;
                AnalyzingLabel.Top = (LoadingPanel.Height / 2) - (AnalyzingLabel.Height / 2);
                AnalyzingLabel.Left = (LoadingPanel.Width / 2) - (AnalyzingLabel.Width / 2);
            }

            LoadingPanel.Visible = text != null;
        }

        private void EnableControls<T>(bool enable = true) where T: Control
        {
            foreach (Control control in Controls)
            {
                if (typeof(T) == typeof(Control) || control.GetType() == typeof(T))
                {
                    if (control is GroupBox)
                    {
                        control.Visible = enable;
                    }
                    else if (control != LoadingPanel
                        && control != ApplyButton)
                    {
                        control.Enabled = enable;
                    }
                }
            } 
        }

        private void EnableGroupBoxes(bool? enable = null)
        {
            foreach (Control control in Controls)
            {
                if (control is GroupBox)
                {
                    if (enable.HasValue)
                    {
                        control.Enabled = enable.Value;
                        continue;
                    }

                    var disabled = true;

                    foreach (Control c in control.Controls)
                    {
                        if (c.Enabled)
                        {
                            disabled = false;
                            break;
                        }
                    }

                    control.Enabled = !disabled;
                }
            }
        }
        
        private void AssignControlsEvents(Control.ControlCollection controls)
        {
            /*Details.GotFocus += (senderq, e) => {
                this.ActiveControl = null;
            };*/

            foreach (Control control in controls)
            {
                control.MouseEnter += Control_MouseEnter;
                control.MouseLeave += Control_MouseLeave;
                AssignControlsEvents(control.Controls);

                if (control.Parent is GroupBox)
                {
                    if (control is RadioButton rb)
                    {
                        rb.CheckedChanged += Setting_Changed;
                    }
                    else if (control is CheckBox cb)
                    {
                        cb.CheckedChanged += Setting_Changed;
                    }
                }
            }
        }

        private void Control_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((Control)sender).AccessibleDescription))
            {
                DetailsLabel.Text = ((Control)sender).AccessibleDescription;
                DetailsPanel.Visible = true;
                DetailsTimer.Enabled = false;
            }
        }

        private void Control_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((Control)sender).AccessibleDescription))
            {
                DetailsTimer.Enabled = false;
                DetailsTimer.Enabled = true;
            }
        }

        private void DetailsTimer_Tick(object sender, EventArgs e)
        {
            DetailsLabel.Text = "";
            DetailsPanel.Visible = false;
        }

        private void Setting_Changed(object sender, EventArgs e)
        {
            if (sender is Control c && c.Focused)
            {
                ApplyButton.Enabled = ExeSettings != GetSettings();
            }
        }

        private void BackupCB_CheckedChanged(object sender, EventArgs e)
        {
            if (BackupCB.Focused)
            {
                Config.MakeBackup = BackupCB.Checked;
                Config.Save();
            }
        }

        private void EnButton_Click(object sender, EventArgs e)
        {
            Config.Language = "EN";
            Config.Save();
            ApplyCurrentLanguage();
        }

        private void RuButton_Click(object sender, EventArgs e)
        {
            Config.Language = "RU";
            Config.Save();
            ApplyCurrentLanguage();
        }

        private List<Control> GetAllControls(Control parent, List<Control> list = null)
        {
            if (list == null)
            {
                list = new List<Control>();
            }

            list.Add(parent);

            foreach (Control control in parent.Controls)
            {
                GetAllControls(control, list);
            }

            return list;
        }

        private void GitHubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/IDizor/EI-ReHex");
        }
    }
}
