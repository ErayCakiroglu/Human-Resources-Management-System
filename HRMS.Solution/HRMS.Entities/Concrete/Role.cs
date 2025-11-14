using HRMS.Entities.Abstract;

namespace HRMS.Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public Role()
        {
            DepartmentRoles = new List<DepartmentRole>();
            EmployeeDepartmentRoles = new List<EmployeeDepartmentRole>();
        }
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public ICollection<DepartmentRole> DepartmentRoles { get; set; }
        public ICollection<EmployeeDepartmentRole> EmployeeDepartmentRoles { get; set; }
    }
}
