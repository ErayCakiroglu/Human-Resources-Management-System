using System.Linq.Expressions;

namespace HRMS.Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        public TEntity? Get(Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>,
            IQueryable<TEntity>>? include = null,
            bool ignoreQueryFilters = false);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null,
                             Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
                             bool ignoreQueryFilters = false);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        int Count(Expression<Func<TEntity, bool>> expression);
        bool Any(Expression<Func<TEntity, bool>> expression);
    }
}
