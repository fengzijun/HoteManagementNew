using HoteManagement.Configuration;
using System;

namespace HoteManagement.Data
{
    /// <summary>
    /// Base data provider manager
    /// </summary>
    public abstract class BaseDataProviderManager
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settings">Data settings</param>
        protected BaseDataProviderManager(ArticleConfig settings)
        {
            if (settings == null)
                throw new ArgumentNullException("settings");
            this.Settings = settings;
        }

        /// <summary>
        /// Gets or sets settings
        /// </summary>
        protected ArticleConfig Settings { get; private set; }

        /// <summary>
        /// Load data provider
        /// </summary>
        /// <returns>Data provider</returns>
        public abstract IDataProvider LoadDataProvider();
    }
}