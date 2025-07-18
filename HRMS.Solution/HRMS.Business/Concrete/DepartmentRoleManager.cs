using HRMS.Business.Abstract;
using HRMS.Business.Constants;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.DepartmentRole;
using System.Data;

namespace HRMS.Business.Concrete
{
    public class DepartmentRoleManager : IDepartmentRoleService
    {
        private readonly IDepartmentRoleDal _departmentRoleDal;

        public DepartmentRoleManager(IDepartmentRoleDal departmentRoleDal)
        {
            _departmentRoleDal = departmentRoleDal;
        }
        public Result Add(CreateDepartmentRoleDTO departmentRole)
        {

            if (_departmentRoleDal.Any(dr =>
                dr.DepartmentId == departmentRole.DepartmentId &&
                dr.RoleId == departmentRole.RoleId))
                return new Result(false, Messages.IncludesMessage(departmentRole.ToString()));

            var addedDepartmentRole = new DepartmentRole
            {
                DepartmentId = departmentRole.DepartmentId,
                RoleId = departmentRole.RoleId
            };

            _departmentRoleDal.Add(addedDepartmentRole);
            return new Result(true, Messages.AddedMessage(departmentRole.ToString()));
        }

        public Result Update(UpdateDepartmentRoleDTO departmentRole)
        {
            var updatedDepartmentRole = _departmentRoleDal.Get(dr => dr.Id == departmentRole.Id);

            if (updatedDepartmentRole == null)
                return new Result(false, Messages.NotFoundMessage($"DepartmentRole Id: {departmentRole.Id}"));

            if (departmentRole.IsActive != null)
                updatedDepartmentRole.IsActive = Convert.ToBoolean(departmentRole.IsActive);

            if (departmentRole.RoleId != null)
                updatedDepartmentRole.RoleId = Convert.ToInt32(departmentRole.RoleId);

            updatedDepartmentRole.UpdatedAt = DateTime.Now;

            _departmentRoleDal.Update(updatedDepartmentRole);
            return new Result(true, Messages.UpdatedMessage(departmentRole.ToString()));
        }

        public Result Delete(DeleteDepartmentRoleDTO departmentRole)
        {
            var deletedDepartmentRole = _departmentRoleDal.Get(dr => dr.Id == departmentRole.Id);
            if (deletedDepartmentRole == null)
                return new Result(false, Messages.NotFoundMessage($"DepartmentRole Id: {departmentRole.Id}"));

            deletedDepartmentRole.IsDeleted = true;
            deletedDepartmentRole.IsActive = false;
            deletedDepartmentRole.UpdatedAt = DateTime.Now;

            _departmentRoleDal.Update(deletedDepartmentRole);
            return new Result(true, Messages.DeletedMessage(departmentRole.ToString()));
        }

        public DataResult<DepartmentRoleDetailsDTO> GetById(int id)
        {
            var departmentRole = _departmentRoleDal.GetWithDepartmentAndRole(id);

            if (departmentRole == null)
                return new DataResult<DepartmentRoleDetailsDTO>(null, false,
                    Messages.NotFoundMessage($"DepartmentRole Id: {id}"));


            var departmentRoleToDTO = new DepartmentRoleDetailsDTO
            {
                DepartmentName = departmentRole.Department?.Name ?? string.Empty,
                RoleName = departmentRole.Role?.RoleName ?? string.Empty,
                IsActive = departmentRole.IsActive,
            };

            return new DataResult<DepartmentRoleDetailsDTO>(departmentRoleToDTO, true,
                Messages.WasBroughtMessage(departmentRole.ToString()));
        }

        public DataResult<List<DepartmentRoleDetailsDTO>> GetAllDetails()
        {
            var departmentRoleDTOList = _departmentRoleDal
                        .GetAllWithDetails()
                        .Select(dr => new DepartmentRoleDetailsDTO
                        {
                            Id = dr.Id,
                            DepartmentName = dr.Department.Name,
                            RoleName = dr.Role.RoleName,
                            IsActive = dr.IsActive
                        }
                        ).ToList();

            return new DataResult<List<DepartmentRoleDetailsDTO>>(departmentRoleDTOList, true,
                Messages.ListedMessage("Departments-role listed"));
        }
    }
}
