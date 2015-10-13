namespace Plugin.Architecture.Core
{
    public interface IPluginProvider
    {
        string GetContent();

        string Process();
    }
}