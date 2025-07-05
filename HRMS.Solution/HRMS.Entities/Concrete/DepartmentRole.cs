using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class DepartmentRole : BaseEntity, IEntity
    {
        public DepartmentRole()
        {
            Employees = new List<Employee>();
        }
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
