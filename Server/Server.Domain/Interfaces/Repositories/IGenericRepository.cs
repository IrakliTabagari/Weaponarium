using System.Linq.Expressions;
using Server.Domain.Entities;

namespace Server.Domain.Interfaces.Repositories;

public interface IGenericRepository<TEntity, TIdentity> where TEntity: BaseEntity<TIdentity>
{
    Task<List<TEntity>> FindListAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");
    Task<TEntity?> FindOneAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        string includeProperties = "");
    IQueryable<TEntity> Query();
    IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> GetByIdAsync(TIdentity id);
    Task InsertAsync(TEntity entity);
    Task DeleteAsync(TIdentity id);
    Task DeleteAsync(TEntity entityToDelete);
    Task UpdateAsync(TEntity entityToUpdate);
    Task DeleteRangeAsync(Expression<Func<TEntity, bool>> filter);
}
