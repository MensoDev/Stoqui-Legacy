using Microsoft.EntityFrameworkCore;
using Stoqui.Kernel.Domain.Data;
using Stoqui.Kernel.Domain.Extensions;
using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Stock.Infrastructure.DataAccess.Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
{

    private readonly StockDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(StockDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => _dbContext;

    public async ValueTask AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async ValueTask<PagingResult<TEntity>> PaginationAsync(Paging<TEntity> paging)
    {
        AssertionConcern.NotNull(paging, "Paging is required for Pagination");

        IQueryable<TEntity> query = _dbSet;


        if (paging.Filter != null)
        {
            query = query.Where(paging.Filter);
        }

        query = paging.IncludeProperties
            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty)
                => current.Include(includeProperty));


        if (paging.OrderBy != null)
        {
            query = paging.OrderBy(query);
        }

        var totalPages = query.GetTotalPage(paging.PageSize);
        var totalItems = await query.CountAsync();
        query = query.Pagination(paging.PageNumber, paging.PageSize);


        return new PagingResult<TEntity>(
            totalPages,
            paging.PageNumber,
            paging.PageSize,
            totalItems,
            await query.ToListAsync());
    }

    public async ValueTask<TEntity?> GetByIdAsync(Guid entityId)
    {
        return await _dbSet.FindAsync(entityId);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}