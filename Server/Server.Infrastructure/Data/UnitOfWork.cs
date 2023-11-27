using Server.Domain.Entities;
using Server.Domain.Interfaces.Repositories;
using Server.Domain.Interfaces.UnitOfWork;

namespace Server.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private GenericRepository<Category, int> _categoryRepository;
    
    #region Properties

    public IGenericRepository<Category, int> CategoryRepository =>
        _categoryRepository ??= new GenericRepository<Category, int>(_dbContext);
    
    #endregion
    
    private readonly WeaponariumDbContext _dbContext;
    private bool _disposed = false;

    public UnitOfWork(WeaponariumDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
 
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)         
            {
                await _dbContext.DisposeAsync();
            }
            _disposed = true;
        }
    }
}