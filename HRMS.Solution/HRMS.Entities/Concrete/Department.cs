using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Concrete
{
    public class Department : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
