using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZirveChallenge.Core.Repositories;

namespace ZirveChallenge.Data.Repositories
{
  
     public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();

        }

        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
           return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRenge(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public  TEntity Update(TEntity entity)
        {
           _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(e =>
            {
                _context.Entry(e).State = EntityState.Modified;
            });
            _dbSet.UpdateRange(entities);
        }
    }
}
