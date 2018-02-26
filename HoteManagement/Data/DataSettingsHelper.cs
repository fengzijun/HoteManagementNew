using HoteManagement.Configuration;
using System;

namespace HoteManagement.Data
{
    /// <summary>
    /// Data settings helper
    /// </summary>
    public partial class DataSettingsHelper
    {
        //private static bool? _databaseIsInstalled;

        /// <summary>
        /// Returns a value indicating whether database is already installed
        /// </summary>
        /// <returns></returns>
        public static bool DatabaseIsInstalled(ArticleConfig config)
        {
            return config.DatabaseIsInstalled;
        }

        //Reset information cached in the "DatabaseIsInstalled" method
        public static void ResetCache()
        {
            // _databaseIsInstalled = null;
        }
    }
}