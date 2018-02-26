using System.Data.Entity.ModelConfiguration;

namespace HoteManagement.Data.Mapping
{
    public abstract class BaseEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseEntityTypeConfiguration()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {
          
        }
    }
}