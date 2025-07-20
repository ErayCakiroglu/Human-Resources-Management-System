using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal(HRMSDbContext context) : EfEntityRepositoryBase<Role,
        HRMSDbContext>(context), IRoleDal
    {
        public List<Role> GetAllWithEmployees()
        {
            return _context.Roles
                .Include(r => r.Employees)
                    .ThenInclude(e => e.Department)
                .ToList();
        }

        public Role? GetWithDetails(Expression<Func<Role, bool>> filter)
        {
            return _context.Roles
                .Include(r => r.Employees)
                .Include(r => r.DepartmentRoles)
                    .ThenInclude(dr => dr.Department)
                .FirstOrDefault(filter);
        }
    }
}
