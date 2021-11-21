namespace Stoqui.Kernel.Domain.Data;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();

}

