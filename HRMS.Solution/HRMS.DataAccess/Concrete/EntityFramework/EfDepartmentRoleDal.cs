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
        public DepartmentRole GetWithDepartment(int id)
        {
            return _context.DepartmentRoles
                    .Include(dr => dr.Department)
                    .FirstOrDefault(dr => dr.Id == id);
        }
    }
}
