using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal(HRMSDbContext context) : EfEntityRepositoryBase<Employee,
        HRMSDbContext>(context), IEmployeeDal
    {
        public List<Employee> GetAllWithDetails()
        {
            return _context.Employees
                    .Include(e => e.DepartmentRole)
                        .ThenInclude(dr => dr.Department)
                    .Include(e => e.DepartmentRole)
                        .ThenInclude(dr => dr.Role)
                    .ToList();
        }

        public Employee GetWithDetails(Expression<Func<Employee, bool>> filter)
        {
            return _context.Employees
                .Include(e => e.DepartmentRole)
                    .ThenInclude(dr => dr.Department)
                .Include(e => e.DepartmentRole)
                    .ThenInclude(dr => dr.Role)
                .FirstOrDefault(filter);
        }
    }
}
