using HRMS.Entities.Abstract;
using HRMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Employee
{
    public class UpdateEmployeeDTO : IDTO
    {
        public int Id { get; set; }
        public int? DepartmentRoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
