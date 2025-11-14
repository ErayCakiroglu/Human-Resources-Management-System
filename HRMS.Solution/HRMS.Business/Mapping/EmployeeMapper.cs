using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Employee;

namespace HRMS.Business.Mapping
{

    public static class EmployeeMapper
    {
        public static EmployeeSummaryDTO ToSummaryDto(this Employee e) =>
        new()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Email = e.Email,
            PhoneNumber = e.PhoneNumber,
            EmployeeCode = e.EmployeeCode,

            Positions = e.EmployeeDepartmentRoles
                .Where(edr => edr.IsActive && !edr.IsDeleted)
                .Select(edr => new EmployeePositionDTO
                {
                    DepartmentName = edr.Department?.Name ?? "",
                    RoleName = edr.Role?.RoleName ?? ""
                }).ToList(),

        };

        public static EmployeeDetailDTO ToDetailDto(this Employee e) =>
            new()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                EmployeeCode = e.EmployeeCode,

                Positions = e.EmployeeDepartmentRoles
                    .Where(edr => edr.IsActive && !edr.IsDeleted)
                    .Select(edr => new EmployeePositionDTO
                    {
                        DepartmentName = edr.Department?.Name ?? "",
                        RoleName = edr.Role?.RoleName ?? ""
                    }).ToList(),

                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
    }
}