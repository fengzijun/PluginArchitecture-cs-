namespace Plugin.Architecture.Core
{
    public interface IPlugin
    {
        void Execute(PluginContext context);
    }
}