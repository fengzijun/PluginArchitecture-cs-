using System.Collections.Generic;
using System.Text;

namespace Plugin.Architecture.Common
{
    public static class MethodExtension
    {
        public static string ForeachForDictionary(this IDictionary<string, string> dictionary)
        {
            StringBuilder str = new StringBuilder();
            foreach (var key in dictionary.Keys)
            {
                str.Append(key + "|" + dictionary[key]);
                str.Append("###");
            }

            return str.ToString();
        }
    }
}