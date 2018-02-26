using System;
using System.Collections.Generic;
using System.Linq;

namespace HoteManagement.Service.Logging
{
    /// <summary>
    /// Default logger
    /// </summary>
    public partial class DefaultLogger : ILogger
    {
        private static log4net.ILog logger = log4net.LogManager.GetLogger("Logger");

        private Exception GetInnerException(Exception ex)
        {
            Exception innerexcept = ex;
            while ((innerexcept = ex.InnerException) != null)
            {
                ex = innerexcept.InnerException;
            }

            return innerexcept;
        }

        public void WriteLog(string message)
        {
            try
            {
                if (logger.IsInfoEnabled)
                {
                    logger.Info(message);
                }
                //logger.Info(message);
            }
            catch
            {
            }
        }

        public void WriteErrorLog(string message, Exception ex)
        {
            try
            {
                if (ex is ArticleWarningException)
                    logger.Warn(message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite);
                else if (ex is ArticleInfoException)
                    logger.Info(message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite);
                else if (ex is ArticleArgumentNullException)
                    logger.Warn(message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite);
                else if (ex is ArticleException)
                    logger.Error(message + "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite);
                else
                    logger.Error(message + "\n" + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace + "\n" + ex.TargetSite);
            }
            catch
            {
            }
        }

        public void WriteErrorLog(Exception ex)
        {
            try
            {
                Exception innerexception = GetInnerException(ex);

                if (ex is ArticleWarningException)
                    logger.Warn(innerexception.Message + "\n" + innerexception.Source + "\n" + innerexception.StackTrace + "\n" + innerexception.TargetSite);
                else if (ex is ArticleInfoException)
                    logger.Info(innerexception.Message + "\n" + innerexception.Source + "\n" + innerexception.StackTrace + "\n" + innerexception.TargetSite);
                else if (ex is ArticleArgumentNullException)
                    logger.Warn(innerexception.Message + "\n" + innerexception.Source + "\n" + innerexception.StackTrace + "\n" + innerexception.TargetSite);
                else if (ex is ArticleException)
                    logger.Error(innerexception.Message + "\n" + innerexception.Source + "\n" + innerexception.StackTrace + "\n" + innerexception.TargetSite);
                else
                    logger.Error(innerexception.Message + "\n" + innerexception.Source + "\n" + innerexception.StackTrace + "\n" + innerexception.TargetSite);
            }
            catch
            {
            }
        }

        public void WriteWarn(string message)
        {
            try
            {
                if (logger.IsWarnEnabled)
                {
                    logger.Warn(message);
                }
            }
            catch
            {
            }
        }
    }
}