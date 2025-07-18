using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentRoleDal(HRMSDbContext context) : EfEntityRepositoryBase<DepartmentRole,
        HRMSDbContext>(context),
        IDepartmentRoleDal
    {
        public DepartmentRole GetWithDepartmentAndRole(int id)
        {
            return _context.DepartmentRoles
                           .Include(dr => dr.Department)
                           .Include(dr => dr.Role)
                           .FirstOrDefault(dr => dr.Id == id);
        }

        public List<DepartmentRole> GetAllWithDetails()
        {
            return _context.DepartmentRoles
                           .Include(dr => dr.Department)
                           .Include(dr => dr.Role)
                           .ToList();
        }
    }
}
