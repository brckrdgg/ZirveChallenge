using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZirveChallenge.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int Id);

        Task<IQueryable<TEntity>> GetAllAsync();

       Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task Insert(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRenge(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);


    }
}
