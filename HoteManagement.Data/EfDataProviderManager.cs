using HoteManagement.Configuration;
using System;

namespace HoteManagement.Data
{
    public partial class EfDataProviderManager : BaseDataProviderManager
    {
        public EfDataProviderManager(ArticleConfig settings) : base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {
            var providerName = Settings.DataProviderName;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new ArticleException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "sqlserver":
                    return new SqlServerDataProvider();

                case "sqlce":
                    return new SqlCeDataProvider();

                default:
                    throw new ArticleException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }
    }
}