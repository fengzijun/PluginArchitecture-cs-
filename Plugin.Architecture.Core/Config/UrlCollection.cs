using System;
using System.Collections.Generic;
using System.Configuration;

namespace Plugin.Architecture.Core.Config
{
    public class UrlCollection : ConfigurationElementCollection
    {
        private IDictionary<string, string> settings;

        protected override ConfigurationElement CreateNewElement()
        {
            return new UrlElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            UrlElement ep = (UrlElement)element;

            return ep.Key;
        }

        protected override string ElementName
        {
            get
            {
                return base.ElementName;
            }
        }

        public IDictionary<string, string> Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = new Dictionary<string, string>();
                    foreach (UrlElement e in this)
                    {
                        settings.Add(e.Key, e.Value);
                    }
                }
                return settings;
            }
        }

        public new string this[string key]
        {
            get
            {
                string isLoad = string.Empty;

                if (settings == null)
                {
                    settings = new Dictionary<string, string>();
                    foreach (UrlElement e in this)
                    {
                        settings.Add(e.Key, e.Value);
                    }
                }

                if (settings.TryGetValue(key, out isLoad))
                {
                    return isLoad;
                }
                else
                {
                    throw new ArgumentException("没有对'" + key + "'节点进行配置。");
                }
            }
        }
    }
}