
namespace EIReHex
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SelectExeButton = new System.Windows.Forms.Button();
            this.SelectGameExeDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectedFileLabel = new System.Windows.Forms.Label();
            this.GameExePathTextBox = new System.Windows.Forms.TextBox();
            this.RunAmountGroupBox = new System.Windows.Forms.GroupBox();
            this.RunAmountBattleCB = new System.Windows.Forms.CheckBox();
            this.RunAmountManaRB = new System.Windows.Forms.RadioButton();
            this.RunAmountDoubleRB = new System.Windows.Forms.RadioButton();
            this.RunAmountDefaultRB = new System.Windows.Forms.RadioButton();
            this.GameSpeedGroupBox = new System.Windows.Forms.GroupBox();
            this.GameSpeedSuperCB = new System.Windows.Forms.CheckBox();
            this.GameSpeedFastRB = new System.Windows.Forms.RadioButton();
            this.GameSpeedDefaultRB = new System.Windows.Forms.RadioButton();
            this.VillageSpeedGroupBox = new System.Windows.Forms.GroupBox();
            this.VillageSpeedX3RB = new System.Windows.Forms.RadioButton();
            this.VillageSpeedX2RB = new System.Windows.Forms.RadioButton();
            this.VillageSpeedDefaultRB = new System.Windows.Forms.RadioButton();
            this.MiscellaneousGroupBox = new System.Windows.Forms.GroupBox();
            this.SecondarySkillsCB = new System.Windows.Forms.CheckBox();
            this.PartyExpCB = new System.Windows.Forms.CheckBox();
            this.SpellConstuctorCB = new System.Windows.Forms.CheckBox();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.AnalyzingLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.BackupCB = new System.Windows.Forms.CheckBox();
            this.DetailsPanel = new System.Windows.Forms.Panel();
            this.DetailsLabel = new System.Windows.Forms.Label();
            this.EnButton = new System.Windows.Forms.Button();
            this.RuButton = new System.Windows.Forms.Button();
            this.DetailsTimer = new System.Windows.Forms.Timer(this.components);
            this.GitHubLink = new EIReHex.LinkLabelEx();
            this.RunAmountGroupBox.SuspendLayout();
            this.GameSpeedGroupBox.SuspendLayout();
            this.VillageSpeedGroupBox.SuspendLayout();
            this.MiscellaneousGroupBox.SuspendLayout();
            this.LoadingPanel.SuspendLayout();
            this.DetailsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectExeButton
            // 
            this.SelectExeButton.Location = new System.Drawing.Point(15, 13);
            this.SelectExeButton.Name = "SelectExeButton";
            this.SelectExeButton.Size = new System.Drawing.Size(119, 23);
            this.SelectExeButton.TabIndex = 0;
            this.SelectExeButton.Text = "Select game.exe";
            this.SelectExeButton.UseVisualStyleBackColor = true;
            this.SelectExeButton.Click += new System.EventHandler(this.SelectExeButton_Click);
            // 
            // SelectGameExeDialog
            // 
            this.SelectGameExeDialog.Filter = "EXE files|*.exe|All files|*.*";
            // 
            // SelectedFileLabel
            // 
            this.SelectedFileLabel.AutoSize = true;
            this.SelectedFileLabel.Location = new System.Drawing.Point(12, 51);
            this.SelectedFileLabel.Name = "SelectedFileLabel";
            this.SelectedFileLabel.Size = new System.Drawing.Size(68, 13);
            this.SelectedFileLabel.TabIndex = 1;
            this.SelectedFileLabel.Text = "Selected file:";
            // 
            // GameExePathTextBox
            // 
            this.GameExePathTextBox.Location = new System.Drawing.Point(15, 67);
            this.GameExePathTextBox.Name = "GameExePathTextBox";
            this.GameExePathTextBox.ReadOnly = true;
            this.GameExePathTextBox.Size = new System.Drawing.Size(477, 20);
            this.GameExePathTextBox.TabIndex = 2;
            // 
            // RunAmountGroupBox
            // 
            this.RunAmountGroupBox.Controls.Add(this.RunAmountBattleCB);
            this.RunAmountGroupBox.Controls.Add(this.RunAmountManaRB);
            this.RunAmountGroupBox.Controls.Add(this.RunAmountDoubleRB);
            this.RunAmountGroupBox.Controls.Add(this.RunAmountDefaultRB);
            this.RunAmountGroupBox.Location = new System.Drawing.Point(15, 107);
            this.RunAmountGroupBox.Name = "RunAmountGroupBox";
            this.RunAmountGroupBox.Size = new System.Drawing.Size(235, 117);
            this.RunAmountGroupBox.TabIndex = 4;
            this.RunAmountGroupBox.TabStop = false;
            this.RunAmountGroupBox.Text = " Characters running time";
            // 
            // RunAmountBattleCB
            // 
            this.RunAmountBattleCB.AccessibleDescription = "";
            this.RunAmountBattleCB.AutoSize = true;
            this.RunAmountBattleCB.Location = new System.Drawing.Point(12, 89);
            this.RunAmountBattleCB.Name = "RunAmountBattleCB";
            this.RunAmountBattleCB.Size = new System.Drawing.Size(137, 17);
            this.RunAmountBattleCB.TabIndex = 3;
            this.RunAmountBattleCB.Text = "Unlimited out of combat";
            this.RunAmountBattleCB.UseVisualStyleBackColor = true;
            // 
            // RunAmountManaRB
            // 
            this.RunAmountManaRB.AccessibleDescription = "";
            this.RunAmountManaRB.AutoSize = true;
            this.RunAmountManaRB.Location = new System.Drawing.Point(12, 66);
            this.RunAmountManaRB.Name = "RunAmountManaRB";
            this.RunAmountManaRB.Size = new System.Drawing.Size(122, 17);
            this.RunAmountManaRB.TabIndex = 2;
            this.RunAmountManaRB.TabStop = true;
            this.RunAmountManaRB.Text = "Depends on stamina";
            this.RunAmountManaRB.UseVisualStyleBackColor = true;
            // 
            // RunAmountDoubleRB
            // 
            this.RunAmountDoubleRB.AccessibleDescription = "";
            this.RunAmountDoubleRB.AutoSize = true;
            this.RunAmountDoubleRB.Location = new System.Drawing.Point(12, 43);
            this.RunAmountDoubleRB.Name = "RunAmountDoubleRB";
            this.RunAmountDoubleRB.Size = new System.Drawing.Size(122, 17);
            this.RunAmountDoubleRB.TabIndex = 1;
            this.RunAmountDoubleRB.TabStop = true;
            this.RunAmountDoubleRB.Text = "Can run twice longer";
            this.RunAmountDoubleRB.UseVisualStyleBackColor = true;
            // 
            // RunAmountDefaultRB
            // 
            this.RunAmountDefaultRB.AccessibleDescription = "";
            this.RunAmountDefaultRB.AutoSize = true;
            this.RunAmountDefaultRB.Location = new System.Drawing.Point(12, 20);
            this.RunAmountDefaultRB.Name = "RunAmountDefaultRB";
            this.RunAmountDefaultRB.Size = new System.Drawing.Size(88, 17);
            this.RunAmountDefaultRB.TabIndex = 0;
            this.RunAmountDefaultRB.TabStop = true;
            this.RunAmountDefaultRB.Tag = "";
            this.RunAmountDefaultRB.Text = "Default value";
            this.RunAmountDefaultRB.UseVisualStyleBackColor = true;
            // 
            // GameSpeedGroupBox
            // 
            this.GameSpeedGroupBox.Controls.Add(this.GameSpeedSuperCB);
            this.GameSpeedGroupBox.Controls.Add(this.GameSpeedFastRB);
            this.GameSpeedGroupBox.Controls.Add(this.GameSpeedDefaultRB);
            this.GameSpeedGroupBox.Location = new System.Drawing.Point(15, 230);
            this.GameSpeedGroupBox.Name = "GameSpeedGroupBox";
            this.GameSpeedGroupBox.Size = new System.Drawing.Size(235, 94);
            this.GameSpeedGroupBox.TabIndex = 5;
            this.GameSpeedGroupBox.TabStop = false;
            this.GameSpeedGroupBox.Text = " Game speed selector";
            // 
            // GameSpeedSuperCB
            // 
            this.GameSpeedSuperCB.AccessibleDescription = "";
            this.GameSpeedSuperCB.AutoSize = true;
            this.GameSpeedSuperCB.Location = new System.Drawing.Point(12, 67);
            this.GameSpeedSuperCB.Name = "GameSpeedSuperCB";
            this.GameSpeedSuperCB.Size = new System.Drawing.Size(214, 17);
            this.GameSpeedSuperCB.TabIndex = 2;
            this.GameSpeedSuperCB.Text = "Super speed when clicked using mouse";
            this.GameSpeedSuperCB.UseVisualStyleBackColor = true;
            // 
            // GameSpeedFastRB
            // 
            this.GameSpeedFastRB.AccessibleDescription = "";
            this.GameSpeedFastRB.AutoSize = true;
            this.GameSpeedFastRB.Location = new System.Drawing.Point(12, 43);
            this.GameSpeedFastRB.Name = "GameSpeedFastRB";
            this.GameSpeedFastRB.Size = new System.Drawing.Size(113, 17);
            this.GameSpeedFastRB.TabIndex = 1;
            this.GameSpeedFastRB.TabStop = true;
            this.GameSpeedFastRB.Text = "High speed values";
            this.GameSpeedFastRB.UseVisualStyleBackColor = true;
            // 
            // GameSpeedDefaultRB
            // 
            this.GameSpeedDefaultRB.AccessibleDescription = "";
            this.GameSpeedDefaultRB.AutoSize = true;
            this.GameSpeedDefaultRB.Location = new System.Drawing.Point(12, 20);
            this.GameSpeedDefaultRB.Name = "GameSpeedDefaultRB";
            this.GameSpeedDefaultRB.Size = new System.Drawing.Size(125, 17);
            this.GameSpeedDefaultRB.TabIndex = 0;
            this.GameSpeedDefaultRB.TabStop = true;
            this.GameSpeedDefaultRB.Text = "Default speed values";
            this.GameSpeedDefaultRB.UseVisualStyleBackColor = true;
            // 
            // VillageSpeedGroupBox
            // 
            this.VillageSpeedGroupBox.Controls.Add(this.VillageSpeedX3RB);
            this.VillageSpeedGroupBox.Controls.Add(this.VillageSpeedX2RB);
            this.VillageSpeedGroupBox.Controls.Add(this.VillageSpeedDefaultRB);
            this.VillageSpeedGroupBox.Location = new System.Drawing.Point(258, 230);
            this.VillageSpeedGroupBox.Name = "VillageSpeedGroupBox";
            this.VillageSpeedGroupBox.Size = new System.Drawing.Size(234, 94);
            this.VillageSpeedGroupBox.TabIndex = 6;
            this.VillageSpeedGroupBox.TabStop = false;
            this.VillageSpeedGroupBox.Text = " Game speed in Villages";
            // 
            // VillageSpeedX3RB
            // 
            this.VillageSpeedX3RB.AccessibleDescription = "";
            this.VillageSpeedX3RB.AutoSize = true;
            this.VillageSpeedX3RB.Location = new System.Drawing.Point(12, 66);
            this.VillageSpeedX3RB.Name = "VillageSpeedX3RB";
            this.VillageSpeedX3RB.Size = new System.Drawing.Size(101, 17);
            this.VillageSpeedX3RB.TabIndex = 2;
            this.VillageSpeedX3RB.TabStop = true;
            this.VillageSpeedX3RB.Text = "Very high speed";
            this.VillageSpeedX3RB.UseVisualStyleBackColor = true;
            // 
            // VillageSpeedX2RB
            // 
            this.VillageSpeedX2RB.AccessibleDescription = "";
            this.VillageSpeedX2RB.AutoSize = true;
            this.VillageSpeedX2RB.Location = new System.Drawing.Point(12, 43);
            this.VillageSpeedX2RB.Name = "VillageSpeedX2RB";
            this.VillageSpeedX2RB.Size = new System.Drawing.Size(79, 17);
            this.VillageSpeedX2RB.TabIndex = 1;
            this.VillageSpeedX2RB.TabStop = true;
            this.VillageSpeedX2RB.Text = "High speed";
            this.VillageSpeedX2RB.UseVisualStyleBackColor = true;
            // 
            // VillageSpeedDefaultRB
            // 
            this.VillageSpeedDefaultRB.AccessibleDescription = "";
            this.VillageSpeedDefaultRB.AutoSize = true;
            this.VillageSpeedDefaultRB.Location = new System.Drawing.Point(12, 20);
            this.VillageSpeedDefaultRB.Name = "VillageSpeedDefaultRB";
            this.VillageSpeedDefaultRB.Size = new System.Drawing.Size(91, 17);
            this.VillageSpeedDefaultRB.TabIndex = 0;
            this.VillageSpeedDefaultRB.TabStop = true;
            this.VillageSpeedDefaultRB.Text = "Default speed";
            this.VillageSpeedDefaultRB.UseVisualStyleBackColor = true;
            // 
            // MiscellaneousGroupBox
            // 
            this.MiscellaneousGroupBox.Controls.Add(this.SecondarySkillsCB);
            this.MiscellaneousGroupBox.Controls.Add(this.PartyExpCB);
            this.MiscellaneousGroupBox.Controls.Add(this.SpellConstuctorCB);
            this.MiscellaneousGroupBox.Location = new System.Drawing.Point(258, 107);
            this.MiscellaneousGroupBox.Name = "MiscellaneousGroupBox";
            this.MiscellaneousGroupBox.Size = new System.Drawing.Size(234, 117);
            this.MiscellaneousGroupBox.TabIndex = 7;
            this.MiscellaneousGroupBox.TabStop = false;
            this.MiscellaneousGroupBox.Text = " Miscellaneous";
            // 
            // SecondarySkillsCB
            // 
            this.SecondarySkillsCB.AccessibleDescription = "";
            this.SecondarySkillsCB.AutoSize = true;
            this.SecondarySkillsCB.Location = new System.Drawing.Point(12, 66);
            this.SecondarySkillsCB.Name = "SecondarySkillsCB";
            this.SecondarySkillsCB.Size = new System.Drawing.Size(139, 17);
            this.SecondarySkillsCB.TabIndex = 6;
            this.SecondarySkillsCB.Text = "Fix secondary skills cost";
            this.SecondarySkillsCB.UseVisualStyleBackColor = true;
            // 
            // PartyExpCB
            // 
            this.PartyExpCB.AccessibleDescription = "";
            this.PartyExpCB.AutoSize = true;
            this.PartyExpCB.Location = new System.Drawing.Point(12, 43);
            this.PartyExpCB.Name = "PartyExpCB";
            this.PartyExpCB.Size = new System.Drawing.Size(177, 17);
            this.PartyExpCB.TabIndex = 5;
            this.PartyExpCB.Text = "Full exp value for party members";
            this.PartyExpCB.UseVisualStyleBackColor = true;
            // 
            // SpellConstuctorCB
            // 
            this.SpellConstuctorCB.AccessibleDescription = "";
            this.SpellConstuctorCB.AutoSize = true;
            this.SpellConstuctorCB.Location = new System.Drawing.Point(12, 20);
            this.SpellConstuctorCB.Name = "SpellConstuctorCB";
            this.SpellConstuctorCB.Size = new System.Drawing.Size(152, 17);
            this.SpellConstuctorCB.TabIndex = 4;
            this.SpellConstuctorCB.Text = "Unlocked spell constructor";
            this.SpellConstuctorCB.UseVisualStyleBackColor = true;
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.Controls.Add(this.AnalyzingLabel);
            this.LoadingPanel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.LoadingPanel.Location = new System.Drawing.Point(0, 107);
            this.LoadingPanel.Margin = new System.Windows.Forms.Padding(0);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(12, 227);
            this.LoadingPanel.TabIndex = 8;
            this.LoadingPanel.Visible = false;
            // 
            // AnalyzingLabel
            // 
            this.AnalyzingLabel.AutoSize = true;
            this.AnalyzingLabel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.AnalyzingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.AnalyzingLabel.Location = new System.Drawing.Point(22, 27);
            this.AnalyzingLabel.Name = "AnalyzingLabel";
            this.AnalyzingLabel.Size = new System.Drawing.Size(283, 26);
            this.AnalyzingLabel.TabIndex = 0;
            this.AnalyzingLabel.Text = "Analyzing file... Please wait.";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ApplyButton.Location = new System.Drawing.Point(140, 13);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(119, 23);
            this.ApplyButton.TabIndex = 9;
            this.ApplyButton.Text = "Apply changes";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // BackupCB
            // 
            this.BackupCB.AutoSize = true;
            this.BackupCB.Location = new System.Drawing.Point(265, 17);
            this.BackupCB.Name = "BackupCB";
            this.BackupCB.Size = new System.Drawing.Size(92, 17);
            this.BackupCB.TabIndex = 10;
            this.BackupCB.Text = "Make backup";
            this.BackupCB.UseVisualStyleBackColor = true;
            this.BackupCB.CheckedChanged += new System.EventHandler(this.BackupCB_CheckedChanged);
            // 
            // DetailsPanel
            // 
            this.DetailsPanel.Controls.Add(this.DetailsLabel);
            this.DetailsPanel.Location = new System.Drawing.Point(0, 37);
            this.DetailsPanel.Name = "DetailsPanel";
            this.DetailsPanel.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.DetailsPanel.Size = new System.Drawing.Size(259, 37);
            this.DetailsPanel.TabIndex = 11;
            this.DetailsPanel.Visible = false;
            // 
            // DetailsLabel
            // 
            this.DetailsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.DetailsLabel.Location = new System.Drawing.Point(10, 2);
            this.DetailsLabel.Name = "DetailsLabel";
            this.DetailsLabel.Size = new System.Drawing.Size(239, 35);
            this.DetailsLabel.TabIndex = 13;
            this.DetailsLabel.Text = "DetailsLabel";
            this.DetailsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnButton
            // 
            this.EnButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EnButton.Location = new System.Drawing.Point(462, 13);
            this.EnButton.Name = "EnButton";
            this.EnButton.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.EnButton.Size = new System.Drawing.Size(30, 23);
            this.EnButton.TabIndex = 12;
            this.EnButton.Text = "EN";
            this.EnButton.UseCompatibleTextRendering = true;
            this.EnButton.UseVisualStyleBackColor = true;
            this.EnButton.Click += new System.EventHandler(this.EnButton_Click);
            // 
            // RuButton
            // 
            this.RuButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RuButton.Location = new System.Drawing.Point(426, 13);
            this.RuButton.Name = "RuButton";
            this.RuButton.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.RuButton.Size = new System.Drawing.Size(30, 23);
            this.RuButton.TabIndex = 13;
            this.RuButton.Text = "RU";
            this.RuButton.UseCompatibleTextRendering = true;
            this.RuButton.UseVisualStyleBackColor = true;
            this.RuButton.Click += new System.EventHandler(this.RuButton_Click);
            // 
            // DetailsTimer
            // 
            this.DetailsTimer.Interval = 200;
            this.DetailsTimer.Tick += new System.EventHandler(this.DetailsTimer_Tick);
            // 
            // GitHubLink
            // 
            this.GitHubLink.AutoSize = true;
            this.GitHubLink.Cursor = System.Windows.Forms.Cursors.Cross;
            this.GitHubLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.GitHubLink.Location = new System.Drawing.Point(454, 51);
            this.GitHubLink.Name = "GitHubLink";
            this.GitHubLink.Size = new System.Drawing.Size(40, 13);
            this.GitHubLink.TabIndex = 15;
            this.GitHubLink.TabStop = true;
            this.GitHubLink.Text = "GitHub";
            this.GitHubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GitHubLink_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 336);
            this.Controls.Add(this.GitHubLink);
            this.Controls.Add(this.RuButton);
            this.Controls.Add(this.EnButton);
            this.Controls.Add(this.BackupCB);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.MiscellaneousGroupBox);
            this.Controls.Add(this.VillageSpeedGroupBox);
            this.Controls.Add(this.GameSpeedGroupBox);
            this.Controls.Add(this.RunAmountGroupBox);
            this.Controls.Add(this.GameExePathTextBox);
            this.Controls.Add(this.SelectedFileLabel);
            this.Controls.Add(this.SelectExeButton);
            this.Controls.Add(this.DetailsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evil Islands modifier - ReHex v1.0";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MouseEnter += new System.EventHandler(this.Control_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Control_MouseLeave);
            this.RunAmountGroupBox.ResumeLayout(false);
            this.RunAmountGroupBox.PerformLayout();
            this.GameSpeedGroupBox.ResumeLayout(false);
            this.GameSpeedGroupBox.PerformLayout();
            this.VillageSpeedGroupBox.ResumeLayout(false);
            this.VillageSpeedGroupBox.PerformLayout();
            this.MiscellaneousGroupBox.ResumeLayout(false);
            this.MiscellaneousGroupBox.PerformLayout();
            this.LoadingPanel.ResumeLayout(false);
            this.LoadingPanel.PerformLayout();
            this.DetailsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SelectExeButton;
        private System.Windows.Forms.OpenFileDialog SelectGameExeDialog;
        private System.Windows.Forms.Label SelectedFileLabel;
        private System.Windows.Forms.TextBox GameExePathTextBox;
        private System.Windows.Forms.GroupBox RunAmountGroupBox;
        private System.Windows.Forms.CheckBox RunAmountBattleCB;
        private System.Windows.Forms.RadioButton RunAmountManaRB;
        private System.Windows.Forms.RadioButton RunAmountDoubleRB;
        private System.Windows.Forms.RadioButton RunAmountDefaultRB;
        private System.Windows.Forms.GroupBox GameSpeedGroupBox;
        private System.Windows.Forms.CheckBox GameSpeedSuperCB;
        private System.Windows.Forms.RadioButton GameSpeedFastRB;
        private System.Windows.Forms.RadioButton GameSpeedDefaultRB;
        private System.Windows.Forms.GroupBox VillageSpeedGroupBox;
        private System.Windows.Forms.RadioButton VillageSpeedX2RB;
        private System.Windows.Forms.RadioButton VillageSpeedDefaultRB;
        private System.Windows.Forms.GroupBox MiscellaneousGroupBox;
        private System.Windows.Forms.CheckBox PartyExpCB;
        private System.Windows.Forms.CheckBox SpellConstuctorCB;
        private System.Windows.Forms.Panel LoadingPanel;
        private System.Windows.Forms.Label AnalyzingLabel;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.CheckBox BackupCB;
        private System.Windows.Forms.Panel DetailsPanel;
        private System.Windows.Forms.Button EnButton;
        private System.Windows.Forms.Button RuButton;
        private System.Windows.Forms.CheckBox SecondarySkillsCB;
        private System.Windows.Forms.RadioButton VillageSpeedX3RB;
        private System.Windows.Forms.Label DetailsLabel;
        private System.Windows.Forms.Timer DetailsTimer;
        private LinkLabelEx GitHubLink;
    }
}

