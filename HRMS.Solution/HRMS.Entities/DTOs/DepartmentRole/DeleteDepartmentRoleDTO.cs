using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.DepartmentRole
{
    public class DeleteDepartmentRoleDTO : IDTO
    {
        public int Id { get; set; }
        public int DeletedByUserId { get; set; }
    }
}
