using System;

namespace HoteManagement.Service.Logging
{
    /// <summary>
    /// Null logger
    /// </summary>
    public partial class NullLogger : ILogger
    {
        public void WriteLog(string message)
        {
        }

        public void WriteErrorLog(string message, Exception ex)
        {
        }

        public void WriteErrorLog(Exception ex)
        {
        }

        public void WriteWarn(string message)
        {
        }
    }
}