using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfRoleDal(HRMSDbContext context) : EfEntityRepositoryBase<Role,
        HRMSDbContext>(context), IRoleDal
    {
    }
}
