using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.DepartmentRelation
{
    public class AssignEmployeeRequestDTO : IDTO
    {
        public int EmployeeId { get; set; }
        public int DepartmentRoleId { get; set; }
    }
}
