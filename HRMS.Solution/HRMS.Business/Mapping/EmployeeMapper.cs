using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DepartmentName = e.DepartmentRole?.Department?.Name ?? "",
            RoleName = e.DepartmentRole?.Role?.RoleName ?? ""
        };

        public static EmployeeDetailDTO ToDetailDto(this Employee e) =>
            new()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                EmployeeCode = e.EmployeeCode,
                DepartmentRoleId = e.DepartmentRoleId,
                DepartmentName = e.DepartmentRole?.Department?.Name ?? "",
                RoleName = e.DepartmentRole?.Role?.RoleName ?? "",
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            };
    }
}
