using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Role
{
    public class RoleSummaryDTO : IDTO
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
