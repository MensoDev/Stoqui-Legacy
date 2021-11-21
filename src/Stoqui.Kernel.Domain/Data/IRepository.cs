using Stoqui.Kernel.Domain.Objects;

namespace Stoqui.Kernel.Domain.Data;

public interface IRepository<T> : IDisposable where T : class, IAggregateRoot
{
    public IUnitOfWork UnitOfWork { get; init; }
}

