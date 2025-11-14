using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace HRMS.Entities.DTOs.Employee
{
    public class EmployeeDetailDTO : IDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public ICollection<EmployeePositionDTO> Positions { get; set; } = new List<EmployeePositionDTO>();

        public int? TerminationReasonId { get; set; }
        public string? TerminationReasonDescription { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string? TerminationExplanation { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}