using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Department
{
    public class CreateDepartmentDTO : IDTO
    {
        public CreateDepartmentDTO()
        {
            RoleIds = new List<int>();
        }
        public string Name { get; set; } = string.Empty;
        public List<int> RoleIds { get; set; }
    }
}
