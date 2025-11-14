using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.Employee
{
    public class EmployeePositionDTO : IDTO
    {
        public int EmployeeDepartmentRoleId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
