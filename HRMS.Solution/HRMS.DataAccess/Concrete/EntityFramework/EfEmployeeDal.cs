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
                .Include(e => e.EmployeeDepartmentRoles)
                    .ThenInclude(edr => edr.Department)
                .Include(e => e.EmployeeDepartmentRoles)
                    .ThenInclude(edr => edr.Role)
                .Include(e => e.TerminationReason)
                .ToList();
        }

        public Employee? GetWithDetails(Expression<Func<Employee, bool>> filter)
        {
            return _context.Employees
                .Include(e => e.EmployeeDepartmentRoles)
                    .ThenInclude(edr => edr.Department)
                .Include(e => e.EmployeeDepartmentRoles)
                    .ThenInclude(edr => edr.Role)
                .Include(e => e.TerminationReason)
                .FirstOrDefault(filter);
        }
    }
}