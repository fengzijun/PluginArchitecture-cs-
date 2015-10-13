using Plugin.Architecture.Core;
using System;

namespace Plugin.PluginA
{
    public class PluginAGenerate : PluginBase
    {
        public override void Execute(PluginContext context)
        {
            IPluginProvider provider = new PluginAContextProvider(context);
            var msg = provider.Process();
            Console.WriteLine(msg);
            Console.WriteLine(context.Config.Name + " executed!");
        }
    }
}