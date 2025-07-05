using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class Employee : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

        public int DepartmentRoleId { get; set; }
        public DepartmentRole DepartmentRole { get; set; }
    }
}
