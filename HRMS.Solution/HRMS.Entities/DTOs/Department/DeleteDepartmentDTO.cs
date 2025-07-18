using HRMS.Entities.Abstract;

namespace HRMS.Entities.DTOs.Department
{
    public class DeleteDepartmentDTO : IDTO
    {
        public int Id { get; set; }
        public string? DeletedBy { get; set; }
        public string? Reason { get; set; }
    }
}
