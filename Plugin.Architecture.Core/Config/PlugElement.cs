using System.Configuration;

namespace Plugin.Architecture.Core.Config
{
    public class PluginElement : ConfigurationElement
    {
        /// <summary>
        ///
        /// </summary>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["Name"]; }
            set { base["Name"] = value; }
        }

        [ConfigurationProperty("Type", IsRequired = false)]
        public string Type
        {
            get { return (string)base["Type"]; }
            set { base["Type"] = value; }
        }

        [ConfigurationProperty("UrlSettings", IsRequired = true)]
        public UrlCollection UrlSettings
        {
            get { return (UrlCollection)base["UrlSettings"]; }
            set { base["UrlSettings"] = value; }
        }

        [ConfigurationProperty("PluginStart", IsRequired = true)]
        public PluginStartSetting PluginStart
        {
            get { return (PluginStartSetting)base["PluginStart"]; }
            set { base["PluginStart"] = value; }
        }
    }
}