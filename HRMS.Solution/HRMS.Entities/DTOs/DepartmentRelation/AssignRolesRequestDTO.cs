using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.DepartmentRelation
{
    public class AssignRolesRequestDTO : IDTO
    {
        public int DepartmentId { get; set; }
        public List<int> RoleIds { get; set; } = new List<int>();
    }
}
