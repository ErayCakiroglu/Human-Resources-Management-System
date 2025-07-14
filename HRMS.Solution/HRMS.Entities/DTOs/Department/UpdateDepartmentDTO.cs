using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Department
{
    public class UpdateDepartmentDTO : IDTO
    {
        public UpdateDepartmentDTO()
        {
            RoleIds = new List<int>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<int>? RoleIds { get; set; }
        public bool? IsActive { get; set; }
    }
}
