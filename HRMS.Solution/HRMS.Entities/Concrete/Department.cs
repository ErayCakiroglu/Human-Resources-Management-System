using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class Department : BaseEntity, IEntity
    {
        public Department()
        {
            Employees = new List<Employee>();
            DepartmentRoles = new List<DepartmentRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; }
        public ICollection<DepartmentRole> DepartmentRoles { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletionReason { get; set; }

    }
}
