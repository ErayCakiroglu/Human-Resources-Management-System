using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class Department : BaseEntity, IEntity
    {
        public Department()
        {
            DepartmentRoles = new List<DepartmentRole>();
            EmployeeDepartmentRoles = new List<EmployeeDepartmentRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<DepartmentRole> DepartmentRoles { get; set; }
        public ICollection<EmployeeDepartmentRole> EmployeeDepartmentRoles { get; set; }

    }
}
