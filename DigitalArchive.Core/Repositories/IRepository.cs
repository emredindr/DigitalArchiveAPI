using DigitalArchive.Core.Entities;
using System.Linq.Expressions;

namespace DigitalArchive.Core.Repositories
{
    public interface IRepository<TEntity,TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        IQueryable<TEntity> GetAll();
        
        TEntity Get(TPrimaryKey id);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(TPrimaryKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate = null);
        //Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate = null);

        TEntity Insert(TEntity entity);
        TPrimaryKey InsertAndGetId(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        //TEntity InsertOrUpdate(TEntity entity);
        //TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        //Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        //Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        bool Delete(TPrimaryKey id);
        //bool Delete(TEntity entity);
        //bool Delete(Expression<Func<TEntity, bool>> predicate);
        Task<bool> DeleteAsync(TPrimaryKey id);
        //Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        //Task<bool> DeleteAsync(TEntity entity);

        Task<bool> RemoveAsync(TPrimaryKey id);


    }
}
