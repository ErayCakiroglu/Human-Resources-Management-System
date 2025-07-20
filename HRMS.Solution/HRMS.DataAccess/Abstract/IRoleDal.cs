using HRMS.Core.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using System.Linq.Expressions;

namespace HRMS.DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
        List<Role> GetAllWithEmployees();
        Role? GetWithDetails(Expression<Func<Role, bool>> filter);
    }
}
