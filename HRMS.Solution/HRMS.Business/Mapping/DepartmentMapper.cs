using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Department;
using HRMS.Entities.DTOs.Employee;
using HRMS.Entities.DTOs.Role;

namespace HRMS.Business.Mapping
{
    public static class DepartmentMapper
    {
        public static DepartmentDetailsDTO MapToDetailsDTO(Department department)
        {
            var dto = new DepartmentDetailsDTO
            {
                Id = department.Id,
                Name = department.Name,
                IsActive = department.IsActive,
                CreatedAt = department.CreatedAt,
                Roles = new List<RoleSummaryDTO>(),
                Employees = new List<EmployeeSummaryDTO>()
            };

            foreach (var departmentRole in department.DepartmentRoles)
            {
                if (departmentRole.Role != null && !departmentRole.IsDeleted)
                {
                    dto.Roles.Add(new RoleSummaryDTO
                    {
                        Id = departmentRole.Role.Id,
                        RoleName = departmentRole.Role.RoleName
                    });
                }

                foreach (var employee in departmentRole.Employees)
                {
                    if (!employee.IsDeleted)
                    {
                        dto.Employees.Add(new EmployeeSummaryDTO
                        {
                            Id = employee.Id,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Email = employee.Email,
                            PhoneNumber = employee.PhoneNumber,
                            EmployeeCode = employee.EmployeeCode,
                            DepartmentName = department.Name,
                            RoleName = departmentRole.Role?.RoleName ?? "",
                            DepartmentRoleId = departmentRole.Id
                        });
                    }
                }
            }

            return dto;
        }
    }
}
