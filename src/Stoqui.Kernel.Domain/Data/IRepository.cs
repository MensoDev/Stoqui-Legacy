using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Kernel.Domain.Data;

public interface IRepository<TEntity> : IDisposable where TEntity : class, IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; }



    //Generic Setters
    ValueTask AddAsync(TEntity entity);

    //Generic Getters
    ValueTask<PagingResult<TEntity>> PaginationAsync(Paging<TEntity> paging);
    ValueTask<TEntity?> GetByIdAsync(Guid entityId);

    //Generic Updates
    void Update(TEntity entity);

    //Generic Deletes
    void Delete(TEntity entity);
}

