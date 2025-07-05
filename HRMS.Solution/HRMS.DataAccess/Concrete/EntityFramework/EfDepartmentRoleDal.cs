using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentRoleDal(HRMSDbContext context) : EfEntityRepositoryBase<DepartmentRole,
        HRMSDbContext>(context),
        IDepartmentRoleDal
    {
    }
}
