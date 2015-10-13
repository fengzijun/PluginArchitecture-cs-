using System.Configuration;

namespace Plugin.Architecture.Core.Config
{
    public class PluginCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PluginElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            PluginElement ep = (PluginElement)element;

            return ep.Name;
        }

        public PluginElement this[int index]
        {
            get { return (PluginElement)base.BaseGet(index); }
        }

        public new PluginElement this[string name]
        {
            get { return (PluginElement)base.BaseGet(name); }
        }
    }
}