using HRMS.Entities.Abstract;
using System.Collections.Generic;

namespace HRMS.Entities.DTOs.Employee
{
    public class EmployeeSummaryDTO : IDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string EmployeeCode { get; set; } = string.Empty;
        public ICollection<EmployeePositionDTO> Positions { get; set; } = new List<EmployeePositionDTO>();
    }
}