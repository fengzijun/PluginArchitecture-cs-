using System;

namespace Plugin.Architecture.Core
{
    public abstract class PluginProviderBase : IPluginProvider
    {
        protected PluginContext DataContext;

        protected PluginProviderBase(PluginContext dataContext)
        {
            DataContext = dataContext;
        }

        public abstract string GetContent();

        /// <summary>
        /// init data
        /// </summary>
        /// <returns></returns>
        public virtual bool Init()
        {
            var context = DataContext as DataContext;

            try
            {
                return true;
            }
            catch (Exception ex)
            {
                throw new DataContextException(context, ex.Message, ex);
            }
        }

        public string Process()
        {
            if (!Init())
                return null;

            string content = GetContent();

            return content;
        }
    }
}