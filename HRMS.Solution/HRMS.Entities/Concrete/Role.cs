using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public Role()
        {
            Employees = new List<Employee>();
            DepartmentRoles = new List<DepartmentRole>();
        }
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; }
        public ICollection<DepartmentRole> DepartmentRoles { get; set; }
    }
}
