using Plugin.Architecture.Core;
using System;

namespace Plugin.PluginB
{
    public class PluginBGenerate : PluginBase
    {
        public override void Execute(PluginContext context)
        {
            IPluginProvider provider = new PluginBContextProvider(context);
            var msg = provider.Process();
            Console.WriteLine(msg);
            Console.WriteLine(context.Config.Name + " executed!");
        }
    }
}