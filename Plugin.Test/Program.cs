using Plugin.Architecture.Core;
using Plugin.Architecture.Core.Config;
using System;
using System.Collections.Generic;

namespace Plugin.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<IPlugin> plugins = PluginManager.GetExecutePlugin();
            PluginCollection configs = PluginManager.GetPlugins();
            for (int i = 0; i < plugins.Count; i++)
            {
                PluginContext context = PluginManager.GetExecutePluginContext(configs[i].Name);
                context.Config = PluginManager.GetPluginConfig(configs[i].Name);
                Console.WriteLine(configs[i].Name + " running .....");
                plugins[i].Execute(context);
                Console.WriteLine(configs[i].Name + " complete .....");
            }

            Console.WriteLine("complete");
            Console.ReadKey();
        }
    }
}