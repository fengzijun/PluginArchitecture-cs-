namespace Plugin.Architecture.Core
{
    public abstract class PluginBase : IPlugin
    {
        public abstract void Execute(PluginContext context);
    }
}