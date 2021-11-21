using Stoqui.Kernel.Domain.Data;
using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Catalog.Infrastructure.DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IAggregateRoot
    {

        protected readonly CatalogDbContext dbContext;

        public RepositoryBase(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IUnitOfWork UnitOfWork => dbContext;

        public virtual void Dispose()
        {
            dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
