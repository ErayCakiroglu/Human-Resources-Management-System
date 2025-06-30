using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Concrete
{
    public class DepartmentRole : BaseEntity, IEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
