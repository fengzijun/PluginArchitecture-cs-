using Plugin.Architecture.Common;
using Plugin.Architecture.Core;
using System;
using System.Collections.Generic;

namespace Plugin.PluginB
{
    public class PluginBContextProvider : PluginProviderBase
    {
        public PluginBContextProvider(PluginContext dataContext) : base(dataContext)
        {
        }

        public override bool Init()
        {
            //return base.Init();
            var context = DataContext as PlguinBDataContext;
            if (context == null)
                throw new ArgumentException("context should not be null");
            if (context.Datas == null)
                context.Datas = new Dictionary<string, string>();
            context.Datas.Add("1", "HHHHH");
            context.Datas.Add("2", "BBBBB");

            return true;
        }

        public override string GetContent()
        {
            var context = DataContext as PlguinBDataContext;
            try
            {
                return string.Join("|", context.Config.Name, context.Config.Type, context.Datas.ForeachForDictionary());
            }
            catch (Exception ex)
            {
                throw new DataContextException(context, ex.Message, ex);
            }
        }
    }
}