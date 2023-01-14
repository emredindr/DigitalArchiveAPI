using DigitalArchive.Core.Authorization;
using DigitalArchive.Core.Entities;
using DigitalArchive.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigitalArchive.DataAccess.EntityFrameworkCore.Repositories
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<TEntity> _dbSet;
        private readonly IUserManager _userManager;
        public Repository(AppDbContext appDbContext, IUserManager userManager)
        {
            _appDbContext = appDbContext ?? throw new ArgumentException(nameof(appDbContext));
            _dbSet = _appDbContext.Set<TEntity>();
            _userManager = userManager;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
        public TEntity Get(TPrimaryKey id)
        {
            return _dbSet.Find(id);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }
        public async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }


        public TEntity Insert(TEntity entity)
        {
            SetCreationAudit(entity);

            _dbSet.Add(entity);
            _appDbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            SetCreationAudit(entity);

            _dbSet.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
        public TPrimaryKey InsertAndGetId(TEntity entity)
        {
            _dbSet.Add(entity);
            _appDbContext.SaveChanges();
            return entity.Id;
        }
        public async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity.Id;
        }

        public TEntity Update(TEntity entity)
        {
            SetModificationAudit(entity);

            _dbSet.Update(entity);
            _appDbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            SetModificationAudit(entity);

            _dbSet.Update(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public bool Delete(TPrimaryKey id)
        {
            var record = _dbSet.Find(id);

            SetDeletionAudit(record);

            _dbSet.Update(record);
            _appDbContext.SaveChanges();
            return true;
        }
        public async Task<bool> DeleteAsync(TPrimaryKey id)
        {
            var record = await _dbSet.FindAsync(id);

            SetDeletionAudit(record);

            _dbSet.Update(record);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RemoveAsync(TPrimaryKey id)
        {
            var record = await _dbSet.FindAsync(id);
            _dbSet.Remove(record);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        private TEntity SetCreationAudit(TEntity entity)
        {
            var currentUserId = _userManager.GetCurrentUserId();

            entity = SetCustomProperty(entity, "IsDeleted", false);
            entity = SetCustomProperty(entity, "CreationTime", DateTime.UtcNow);
            entity = SetCustomProperty(entity, "CreatorUserId", currentUserId);

            return entity;
        }
        private TEntity SetModificationAudit(TEntity entity)
        {
            var currentUserId = _userManager.GetCurrentUserId();

            entity = SetCustomProperty(entity, "LastModificationTime", DateTime.UtcNow);
            entity = SetCustomProperty(entity, "LastModifierUserId", currentUserId);

            return entity;
        }
        private TEntity SetDeletionAudit(TEntity entity)
        {
            var currentUserId = _userManager.GetCurrentUserId();

            entity = SetCustomProperty(entity, "IsDeleted", true);
            entity = SetCustomProperty(entity, "DeletionTime", DateTime.UtcNow);
            entity = SetCustomProperty(entity, "DeletorUserId", currentUserId);

            return entity;
        }

        private TEntity SetCustomProperty(TEntity entity, string propertyName, object value)
        {
            var checkProperty = entity.GetType().GetProperty(propertyName);
            if (checkProperty != null)
            {
                if (checkProperty.CanWrite)
                    entity.GetType().GetProperty(propertyName).SetValue(entity, value);
            }
            return entity;
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate = null)
        {
            return predicate==null ? _dbSet.ToList(): _dbSet.Where(predicate).ToList();

           
        }
    }
}
