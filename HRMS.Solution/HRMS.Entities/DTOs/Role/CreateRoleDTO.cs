using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Role
{
    public class CreateRoleDTO : IDTO
    {
        public string RoleName { get; set; } = string.Empty;
    }
}
