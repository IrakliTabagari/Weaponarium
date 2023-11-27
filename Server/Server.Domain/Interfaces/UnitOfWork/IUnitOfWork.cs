using Server.Domain.Entities;
using Server.Domain.Interfaces.Repositories;

namespace Server.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IGenericRepository<Category, int> CategoryRepository { get; }
    
    Task SaveAsync();
    ValueTask DisposeAsync();
}