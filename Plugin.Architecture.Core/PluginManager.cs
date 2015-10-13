using Plugin.Architecture.Core.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Plugin.Architecture.Core
{
    public class PluginManager
    {
        public static string currentPluginName = string.Empty;

        public static PluginCollection GetPlugins()
        {
            PluginConfig pluginconfig = ConfigurationManager.GetSection("PluginSetting") as PluginConfig;
            if (pluginconfig != null)
                return pluginconfig.PluginCollection;
            return null;
        }

        public static PluginElement GetPluginConfig(string name)
        {
            PluginCollection plugins = GetPlugins();
            if (plugins != null)
                return plugins[name];
            return null;
        }

        public static PluginContext GetExecutePluginContext(string name)
        {
            string path = Assembly.GetExecutingAssembly()
                  .Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            PluginCollection pluginconfigs = GetPlugins();
            if (pluginconfigs != null && pluginconfigs.Count > 0)
            {
                for (var i = 0; i < pluginconfigs.Count; i++)
                {
                    if (pluginconfigs[i].Name.ToLower() == name.ToLower())
                    {
                        var filename = path + "\\Plugin\\" + pluginconfigs[i].Name + ".dll";
                        Assembly Plugin = Assembly.LoadFile(filename);
                        var contexttype = Plugin.GetType(pluginconfigs[i].Type);

                        return Activator.CreateInstance(contexttype) as PluginContext;
                    }
                }
            }

            return null;
        }

        public static List<IPlugin> GetExecutePlugin()
        {
            string path = Assembly.GetExecutingAssembly()
                    .Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            PluginCollection pluginconfigs = GetPlugins();
            List<IPlugin> plugins = new List<IPlugin>();
            //List<Type> plugintypes = new List<Type>();
            if (pluginconfigs != null && pluginconfigs.Count > 0)
            {
                for (var i = 0; i < pluginconfigs.Count; i++)
                {
                    var filename = path + "\\Plugin\\" + pluginconfigs[i].Name + ".dll";
                    Assembly pluginAssembly = Assembly.LoadFile(filename);
                    var types = pluginAssembly.GetTypes();
                    foreach (var type in types.Where(s => s.GetInterface(typeof(IPlugin).Name) != null))
                    {
                        IPlugin plugin = Activator.CreateInstance(type) as IPlugin;
                        plugins.Add(plugin);
                    }
                }
            }

            return plugins;
        }

        public static List<IPlugin> GetExecutePluginByAppDomain()
        {
            string path = Assembly.GetExecutingAssembly()
                    .Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            PluginCollection pluginconfigs = GetPlugins();
            List<IPlugin> plugins = new List<IPlugin>();
            List<Type> plugintypes = new List<Type>();
            if (pluginconfigs != null && pluginconfigs.Count > 0)
            {
                for (var i = 0; i < pluginconfigs.Count; i++)
                {
                    currentPluginName = pluginconfigs[i].Name;
                    AppDomainSetup setup = new AppDomainSetup();
                    setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
                    setup.ShadowCopyFiles = "true";
                    AppDomain.CurrentDomain.SetShadowCopyFiles();
                    AppDomain plugInAppDomain = AppDomain.CreateDomain(pluginconfigs[i].Name, null, setup);
                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
                    var filename = path + "\\Plugin\\" + pluginconfigs[i].Name + ".dll";

                    byte[] fileContent;
                    using (FileStream dll = File.OpenRead(filename))
                    {
                        fileContent = new byte[dll.Length];
                        dll.Read(fileContent, 0, (int)dll.Length);
                    }

                    var pluginAssembly = plugInAppDomain.Load(fileContent);

                    //Assembly Plugin = Assembly.LoadFile(filename);
                    var types = pluginAssembly.GetTypes();
                    foreach (var type in types.Where(s => s.GetInterface(typeof(IPlugin).Name) != null))
                    {
                        //IPlugin plugin = plugInAppDomain.CreateInstanceAndUnwrap(pluginAssembly.GetName().FullName, type.FullName) as IPlugin;
                        var plugin = Activator.CreateInstance(type) as IPlugin;
                        plugins.Add(plugin);
                    }
                }
            }

            return plugins;
        }

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string path = Assembly.GetExecutingAssembly()
                   .Location.Substring(0, Assembly.GetExecutingAssembly().Location.LastIndexOf("\\"));
            var fileName = path + "\\Plugin\\" + currentPluginName + ".dll";

            return Assembly.LoadFile(fileName);

            //throw new NotImplementedException();
        }
    }
}