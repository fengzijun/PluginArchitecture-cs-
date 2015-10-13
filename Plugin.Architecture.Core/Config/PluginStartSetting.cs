using System.Configuration;

namespace Plugin.Architecture.Core.Config
{
    public class PluginStartSetting : ConfigurationElement
    {
        [ConfigurationProperty("Time", IsRequired = true)]
        public string Time
        {
            get { return (string)base["Time"]; }
            set { base["Time"] = value; }
        }

        [ConfigurationProperty("AttempCount", IsRequired = true)]
        public int AttempCount
        {
            get { return (int)base["AttempCount"]; }
            set { base["AttempCount"] = value; }
        }

        [ConfigurationProperty("OverCount", IsRequired = true)]
        public int OverCount
        {
            get { return (int)base["OverCount"]; }
            set { base["OverCount"] = value; }
        }

        [ConfigurationProperty("Interval", IsRequired = true)]
        public int Interval
        {
            get { return (int)base["Interval"]; }
            set { base["Interval"] = value; }
        }

        [ConfigurationProperty("SleepTime", IsRequired = false)]
        public int SleepTime
        {
            get { return (int)base["SleepTime"]; }
            set { base["SleepTime"] = value; }
        }
    }
}