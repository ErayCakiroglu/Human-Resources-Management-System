using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.Concrete
{
    public class TerminationReason : BaseEntity, IEntity
    {
        public int Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
