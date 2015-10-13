using System.Configuration;

namespace Plugin.Architecture.Core.Config
{
    public class PluginConfig : ConfigurationSection
    {
        [ConfigurationProperty("PluginCollection", IsRequired = true)]
        [ConfigurationCollection(typeof(PluginCollection), AddItemName = "Plugin")]
        public PluginCollection PluginCollection
        {
            get { return (PluginCollection)base["PluginCollection"]; }
        }
    }
}