using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class Employee : BaseEntity, IEntity
    {
        public int Id { get; set; }

        public int DepartmentRoleId { get; set; }
        public DepartmentRole? DepartmentRole { get; set; }

        public int? TerminationReasonId { get; set; }
        public TerminationReason? TerminationReason { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string? TerminationExplanation { get; set; }

        public string EmployeeCode { get; set; } = string.Empty;

        public Department? Department => DepartmentRole?.Department;

    }
}
