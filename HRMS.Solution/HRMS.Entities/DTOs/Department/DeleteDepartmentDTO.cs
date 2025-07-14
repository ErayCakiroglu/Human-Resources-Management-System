using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Department
{
    public class DeleteDepartmentDTO : IDTO
    {
        public int Id { get; set; }
        public string? DeletedBy { get; set; }
        public string? Reason { get; set; }
    }
}
