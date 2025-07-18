using HRMS.Core.DataAccess.Abstract;
using HRMS.Entities.Concrete;

namespace HRMS.DataAccess.Abstract
{
    public interface IDepartmentRoleDal : IEntityRepository<DepartmentRole>
    {
        DepartmentRole GetWithDepartmentAndRole(int id);
        List<DepartmentRole> GetAllWithDetails();
    }
}
