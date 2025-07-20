using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.Role
{
    public class RoleSummaryDTO : IDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
