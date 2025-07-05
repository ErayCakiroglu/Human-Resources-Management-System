using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal(HRMSDbContext context) : EfEntityRepositoryBase<Department,
        HRMSDbContext>(context),
        IDepartmentDal
    {
    }
}
