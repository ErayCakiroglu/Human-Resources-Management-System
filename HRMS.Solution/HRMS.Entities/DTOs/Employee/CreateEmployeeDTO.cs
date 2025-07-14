using HRMS.Entities.Abstract;
using HRMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Employee
{
    public class CreateEmployeeDTO : IDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int DepartmentRoleId { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
