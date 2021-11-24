using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace EIReHex
{
    public class Configuration
    {
        #region Properties
        public string Language { get; set; } = string.Empty;
        public string GameExePath { get; set; } = string.Empty;
        public bool MakeBackup { get; set; } = true;
        #endregion

        private readonly string ConfigName = Process.GetCurrentProcess().ProcessName + ".cfg";
        private PropertyInfo[] ConfigProperties;
        private Regex ConfigLineRegex = new Regex(@"^\s*(\w+)\s*=\s*(.*)$");

        /// <summary>
        /// Initializes new instance of <see cref="Configuration"/>.
        /// </summary>
        public Configuration()
        {
            ConfigProperties = GetType().GetTypeInfo().DeclaredProperties.ToArray();
        }

        public void Load()
        {
            if (File.Exists(ConfigName))
            {
                var configLines = File.ReadAllLines(ConfigName);

                if (configLines.Length > 0)
                {
                    foreach (var prop in ConfigProperties)
                    {
                        foreach (var line in configLines)
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                var match = ConfigLineRegex.Match(line);

                                if (match.Success && match.Groups[1].Value.Same(prop.Name))
                                {
                                    if (prop.PropertyType == typeof(bool))
                                    {
                                        prop.SetValue(this, bool.Parse(match.Groups[2].Value.Trim()));
                                    }
                                    else
                                    {
                                        prop.SetValue(this, match.Groups[2].Value.Trim());
                                    }

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Save()
        {
            var configLines = File.Exists(ConfigName)
                ? File.ReadAllLines(ConfigName).ToList()
                : new List<string>();

            foreach (var prop in ConfigProperties)
            {
                var propLine = prop.Name + " = " + prop.GetValue(this).ToString();
                var propIndex = configLines.FindIndex(line => Regex.IsMatch(line, $@"^{prop.Name}\s*="));

                if (propIndex >= 0)
                {
                    configLines[propIndex] = propLine;
                }
                else
                {
                    configLines.Add(propLine);
                }
            }

            File.WriteAllLines(ConfigName, configLines);
        }
    }
}
