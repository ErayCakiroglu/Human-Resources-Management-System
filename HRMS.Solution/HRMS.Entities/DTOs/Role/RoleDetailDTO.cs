using HRMS.Entities.Abstract;
using HRMS.Entities.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Role
{
    public class RoleDetailDTO : IDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<EmployeeSummaryDTO> Employees { get; set; } = new();
    }
}
