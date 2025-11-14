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

                Employees = role.EmployeeDepartmentRoles
                    .Where(edr => edr.IsActive && !edr.IsDeleted)
                    .Select(edr => new EmployeeSummaryDTO
                    {
                        Id = edr.Employee.Id,
                        FirstName = edr.Employee.FirstName,
                        LastName = edr.Employee.LastName,
                        Email = edr.Employee.Email,
                        PhoneNumber = edr.Employee.PhoneNumber,
                        EmployeeCode = edr.Employee.EmployeeCode,

                        Positions = new List<EmployeePositionDTO>
                        {
                    new EmployeePositionDTO
                    {
                        DepartmentName = edr.Department?.Name ?? string.Empty,
                        RoleName = role.RoleName,
                        EmployeeDepartmentRoleId = edr.Id
                    }
                        }
                    }).ToList(),

                DepartmentNames = role.DepartmentRoles.Select(dr => dr.Department?.Name ?? string.Empty).ToList()
            }).ToList();

            return new DataResult<List<RoleDetailDTO>>(roleDetailDTOs, true, Messages.ListedMessage("Roles"));
        }

        public DataResult<RoleDetailDTO> GetById(int id)
        {
            var role = _roleDal.GetWithDetails(r => r.Id == id);

            if (role == null)
            {
                return new DataResult<RoleDetailDTO>(null, false, Messages.NotFoundMessage("Role"));
            }

            var dto = new RoleDetailDTO
            {
                Id = role.Id,
                RoleName = role.RoleName,

                DepartmentNames = role.DepartmentRoles.Select(dr => dr.Department?.Name ?? string.Empty).ToList(),

                Employees = role.EmployeeDepartmentRoles
                    .Where(edr => edr.IsActive && !edr.IsDeleted)
                    .Select(edr => new EmployeeSummaryDTO
                    {

                        Positions = new List<EmployeePositionDTO>
                        {
                    new EmployeePositionDTO
                    {
                        DepartmentName = edr.Department?.Name ?? string.Empty,
                        RoleName = role.RoleName,
                        EmployeeDepartmentRoleId = edr.Id
                    }
                        }
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