using Microsoft.EntityFrameworkCore;
using Stoqui.Kernel.Domain.Data;
using Stoqui.Kernel.Domain.Extensions;
using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Catalog.Infrastructure.DataAccess.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
{

    protected  readonly CatalogDbContext context;
    protected  readonly  DbSet<TEntity> dbSet;

    protected RepositoryBase(CatalogDbContext context)
    {
        this.context = context;
        dbSet = context.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => context;
        

    public async ValueTask AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public async ValueTask<PagingResult<TEntity>> PaginationAsync(Paging<TEntity> paging)
    {

        AssertionConcern.NotNull(paging, "Paging is required for Pagination");

        IQueryable<TEntity> query = dbSet;
            

        if (paging.Filter != null)
        {
            query = query.Where(paging.Filter);
        }

        query = paging.IncludeProperties
            .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) 
                => current.Include(includeProperty));


        if (paging.OrderBy != null)
        {
            query = paging.OrderBy(query);
        }

        query.Pagination(paging.PageNumber, paging.PageSize);


        return new PagingResult<TEntity>(
            query.GetTotalPage(paging.PageSize), 
            paging.PageNumber, 
            paging.PageSize, 
            await  query.ToListAsync());
    }

    public async ValueTask<TEntity?> GetByIdAsync(Guid entityId)
    {
        return await dbSet.FindAsync(entityId);
    }

    public void Update(TEntity entity)
    {
        dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        dbSet.Remove(entity);
    }

    public virtual void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}