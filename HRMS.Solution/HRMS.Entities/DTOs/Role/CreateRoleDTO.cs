using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.Role
{
    public class CreateRoleDTO : IDTO
    {
        public string RoleName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public List<int>? EmployeeIds { get; set; }
    }
}
