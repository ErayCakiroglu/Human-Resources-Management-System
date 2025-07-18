using HRMS.Entities.Abstract;
using HRMS.Entities.DTOs.Employee;
using HRMS.Entities.DTOs.Role;

namespace HRMS.Entities.DTOs.Department
{
    public class DepartmentDetailsDTO : IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<RoleSummaryDTO> Roles { get; set; } = new();
        public List<EmployeeSummaryDTO> Employees { get; set; } = new();
    }
}
