using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Abstract
{
    public interface IDepartmentRoleService
    {
        Result Add(DepartmentRole departmentRole);
        Result Update(DepartmentRole departmentRole);
        Result Delete(DepartmentRole departmentRole);
        DataResult<DepartmentRole> GetById(int id);
        DataResult<List<DepartmentRole>> GetAll();
    }
}
