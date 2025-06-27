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
        public int DepartmentId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public Department Department { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
