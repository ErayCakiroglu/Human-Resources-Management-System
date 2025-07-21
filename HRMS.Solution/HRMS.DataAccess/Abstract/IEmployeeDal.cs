using HRMS.Core.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using System.Linq.Expressions;

namespace HRMS.DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<Employee> GetAllWithDetails();
        Employee GetWithDetails(Expression<Func<Employee, bool>> filter);
    }
}
