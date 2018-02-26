﻿using System;
using System.Data.Entity;
using System.Transactions;

namespace HoteManagement.Data.Initializers
{
    /// <summary>
    /// sql ce DropCreateDatabaseIfModelChanges
    /// </summary>
    public class DropCreateCeDatabaseIfModelChanges<TContext> : SqlCeInitializer<TContext> where TContext : DbContext
    {
        #region Strategy implementation

        /// <summary>
        /// Executes the strategy to initialize the database for the given context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var replacedContext = ReplaceSqlCeConnection(context);

            bool databaseExists;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                databaseExists = replacedContext.Database.Exists();
            }

            if (databaseExists)
            {
                if (context.Database.CompatibleWithModel(throwIfNoMetadata: true))
                {
                    return;
                }

                replacedContext.Database.Delete();
            }

            // Database didn't exist or we deleted it, so we now create it again.
            context.Database.Create();

            Seed(context);
            context.SaveChanges();
        }

        #endregion Strategy implementation

        #region Seeding methods

        /// <summary>
        /// A that should be overridden to actually add data to the context for seeding.
        /// The default implementation does nothing.
        /// </summary>
        /// <param name="context">The context to seed.</param>
        protected virtual void Seed(TContext context)
        {
        }

        #endregion Seeding methods
    }
}