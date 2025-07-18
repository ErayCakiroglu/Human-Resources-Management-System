using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.DepartmentRole
{
    public class DepartmentRoleDetailsDTO : IDTO
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? AssignedUserCount { get; set; }
    }
}
