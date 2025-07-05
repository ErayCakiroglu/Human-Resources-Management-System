using System.Linq.Expressions;

namespace HRMS.Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, new()
    {
        TEntity? Get(Expression<Func<TEntity, bool>> expression);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        int Count(Expression<Func<TEntity, bool>> expression);
        bool Any(Expression<Func<TEntity, bool>> expression);
    }
}
