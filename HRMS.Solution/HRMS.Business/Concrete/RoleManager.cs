using HRMS.Business.Abstract;
using HRMS.Business.Constants;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Employee;
using HRMS.Entities.DTOs.Role;

namespace HRMS.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Result Add(CreateRoleDTO roleDTO)
        {
            if (_roleDal.Any(r => r.RoleName == roleDTO.RoleName && !r.IsDeleted))
            {
                return new Result(false, Messages.AlreadyExistsMessage(roleDTO.RoleName));
            }

            var newRole = new Role()
            {
                RoleName = roleDTO.RoleName,
                CreatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _roleDal.Add(newRole);
            return new Result(true, Messages.AddedMessage(newRole.RoleName));
        }

        public Result Delete(DeleteRoleDTO roleDTO)
        {
            var deletedRole = _roleDal.Get(r => r.Id == roleDTO.Id && !r.IsDeleted);
            if (deletedRole == null)
            {
                return new Result(false, Messages.NotFoundMessage("Role"));
            }

            deletedRole.IsDeleted = true;
            deletedRole.IsActive = false;
            deletedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(deletedRole);
            return new Result(true, Messages.DeletedMessage(deletedRole.RoleName));
        }

        public DataResult<List<RoleDetailDTO>> GetAll()
        {
            var roles = _roleDal.GetAllWithEmployees();

            var roleDetailDTOs = roles.Select(role => new RoleDetailDTO
            {
                Id = role.Id,
                RoleName = role.RoleName,
                Employees = role.Employees.Select(emp => new EmployeeSummaryDTO
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email,
                    PhoneNumber = emp.PhoneNumber,
                    EmployeeCode = emp.EmployeeCode,
                    DepartmentName = emp.DepartmentRole?.Department?.Name ?? string.Empty,
                    RoleName = role.RoleName
                }).ToList(),
                DepartmentNames = role.DepartmentRoles.Select(dr => dr.Department?.Name ?? string.Empty).ToList()
            }).ToList();

            return new DataResult<List<RoleDetailDTO>>(roleDetailDTOs, true, Messages.ListedMessage("Roles"));
        }

        public DataResult<RoleDetailDTO> GetById(int id)
        {
            var role = _roleDal.GetWithDetails(r => r.Id == id);
            if (role == null)
                return new DataResult<RoleDetailDTO>(null, false, Messages.NotFoundMessage("Role"));

            var dto = new RoleDetailDTO
            {
                Id = role.Id,
                RoleName = role.RoleName,
                DepartmentNames = role.DepartmentRoles.Select(dr => dr.Department?.Name ?? string.Empty).ToList(),
                Employees = role.Employees.Select(e => new EmployeeSummaryDTO
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    EmployeeCode = e.EmployeeCode,
                    DepartmentName = e.DepartmentRole?.Department?.Name ?? string.Empty,
                    RoleName = role.RoleName
                }).ToList()
            };

            return new DataResult<RoleDetailDTO>(dto, true, Messages.WasBroughtMessage(role.RoleName));
        }

        public Result Update(UpdateRoleDTO roleDTO)
        {
            var updatedRole = _roleDal.Get(r => r.Id == roleDTO.Id);
            if (updatedRole == null)
                return new Result(false, Messages.NotFoundMessage($"Role Id: {roleDTO.Id}"));

            if (roleDTO.IsActive.HasValue)
                updatedRole.IsActive = roleDTO.IsActive.Value;

            if (!string.IsNullOrWhiteSpace(roleDTO.RoleName))
                updatedRole.RoleName = roleDTO.RoleName;

            updatedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(updatedRole);
            return new Result(true, Messages.UpdatedMessage(updatedRole.RoleName));
        }
    }
}
