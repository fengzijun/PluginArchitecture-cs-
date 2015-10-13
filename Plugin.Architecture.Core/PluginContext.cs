using Plugin.Architecture.Core.Config;
using System.Reflection;

namespace Plugin.Architecture.Core
{
    public abstract class PluginContext
    {
        public PluginElement Config { get; set; }

        public virtual string ServicePath
        {
            get
            {
                return Assembly.GetExecutingAssembly()
                    .Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            }
        }
    }
}