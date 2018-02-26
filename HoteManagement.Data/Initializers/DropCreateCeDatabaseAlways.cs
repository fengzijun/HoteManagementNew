using System;
using System.Data.Entity;

namespace HoteManagement.Data.Initializers
{
    /// <summary>
    /// sql ce DropCreateDatabaseAlways
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public class DropCreateCeDatabaseAlways<TContext> : SqlCeInitializer<TContext> where TContext : DbContext
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

            if (replacedContext.Database.Exists())
            {
                replacedContext.Database.Delete();
            }
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