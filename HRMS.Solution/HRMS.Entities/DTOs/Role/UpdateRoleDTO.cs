using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.Role
{
    public class UpdateRoleDTO : IDTO
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool? IsActive { get; set; }
    }
}
