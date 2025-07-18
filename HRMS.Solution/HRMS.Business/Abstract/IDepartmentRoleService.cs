using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.DepartmentRole;

namespace HRMS.Business.Abstract
{
    public interface IDepartmentRoleService
    {
        Result Add(CreateDepartmentRoleDTO departmentRole);
        Result Update(UpdateDepartmentRoleDTO departmentRole);
        Result Delete(DeleteDepartmentRoleDTO departmentRole);
        DataResult<DepartmentRoleDetailsDTO> GetById(int id);
        DataResult<List<DepartmentRoleDetailsDTO>> GetAllDetails();
    }
}
