using System.Collections.Generic;

namespace Plugin.Architecture.Core
{
    public abstract class DataContext : PluginContext
    {
        /// <summary>
        /// custom your data
        /// </summary>
        public IDictionary<string, string> Datas { get; set; }

        public override string ToString()
        {
            var msg = string.Empty;
            var t = GetType();
            var propertyInfos = t.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.GetValue(this, null) != null)
                {
                    msg += propertyInfo.Name + ":" + propertyInfo.GetValue(this, null) + "|";
                }
                else
                    msg += propertyInfo.Name + ":" + string.Empty + "|";
            }

            return msg;
        }
    }
}