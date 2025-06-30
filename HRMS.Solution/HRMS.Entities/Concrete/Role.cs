using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Concrete
{
    public class Role : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<DepartmentRole> DepartmentRoles { get; set; } = new List<DepartmentRole>();
    }
}
