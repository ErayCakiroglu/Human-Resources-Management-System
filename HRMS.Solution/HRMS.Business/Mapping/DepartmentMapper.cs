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
                            Email = employee.Email
                        });
                    }
                }
            }

            return dto;
        }
    }
}
