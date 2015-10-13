using System;

namespace Plugin.Architecture.Core
{
    public class DataContextException : Exception
    {
        public DataContext Datacontext { get; set; }

        public DataContextException(DataContext datacontext, string message)
            : base(message)
        {
            Datacontext = datacontext;
        }

        public DataContextException(DataContext datacontext, string message, Exception innerException)
            : base(message, innerException)
        {
            Datacontext = datacontext;
        }
    }
}