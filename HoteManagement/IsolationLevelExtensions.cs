using System.Data;

namespace HoteManagement
{
    public static class IsolationLevelExtensions
    {
        public static IsolationLevel ToSystemDataIsolationLevel(this System.Transactions.IsolationLevel isolationLevel)
        {
            switch (isolationLevel)
            {
                case System.Transactions.IsolationLevel.Chaos:
                    return IsolationLevel.Chaos;

                case System.Transactions.IsolationLevel.ReadCommitted:
                    return IsolationLevel.ReadCommitted;

                case System.Transactions.IsolationLevel.ReadUncommitted:
                    return IsolationLevel.ReadUncommitted;

                case System.Transactions.IsolationLevel.RepeatableRead:
                    return IsolationLevel.RepeatableRead;

                case System.Transactions.IsolationLevel.Serializable:
                    return IsolationLevel.Serializable;

                case System.Transactions.IsolationLevel.Snapshot:
                    return IsolationLevel.Snapshot;

                case System.Transactions.IsolationLevel.Unspecified:
                    return IsolationLevel.Unspecified;

                default:
                    throw new ArticleException("Unknown isolation level: " + isolationLevel);
            }
        }

        public static System.Transactions.IsolationLevel ToSystemIsolationLevel(this System.Data.IsolationLevel isolationLevel)
        {
            switch (isolationLevel)
            {
                case System.Data.IsolationLevel.Chaos:
                    return System.Transactions.IsolationLevel.Chaos;

                case IsolationLevel.ReadCommitted:
                    return System.Transactions.IsolationLevel.ReadCommitted;

                case IsolationLevel.ReadUncommitted:
                    return System.Transactions.IsolationLevel.ReadUncommitted;

                case IsolationLevel.RepeatableRead:
                    return System.Transactions.IsolationLevel.RepeatableRead;

                case IsolationLevel.Serializable:
                    return System.Transactions.IsolationLevel.Serializable;

                case IsolationLevel.Snapshot:
                    return System.Transactions.IsolationLevel.Snapshot;

                case IsolationLevel.Unspecified:
                    return System.Transactions.IsolationLevel.Unspecified;

                default:
                    throw new ArticleException("Unknown isolation level: " + isolationLevel);
            }
        }
    }
}