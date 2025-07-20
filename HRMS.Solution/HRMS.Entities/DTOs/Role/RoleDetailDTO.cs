using HRMS.Entities.Abstract;
using HRMS.Entities.DTOs.Employee;

namespace HRMS.Entities.DTOs.Role
{
    public class RoleDetailDTO : IDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<string> DepartmentNames { get; set; } = new();
        public List<EmployeeSummaryDTO> Employees { get; set; } = new();
    }
}
