using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Role;

namespace HRMS.Business.Abstract
{
    public interface IRoleService
    {
        Result Add(CreateRoleDTO employee);
        Result Update(UpdateRoleDTO employee);
        Result Delete(DeleteRoleDTO employee);
        DataResult<RoleDetailDTO> GetById(int id);
        DataResult<List<RoleDetailDTO>> GetAll();
    }
}
