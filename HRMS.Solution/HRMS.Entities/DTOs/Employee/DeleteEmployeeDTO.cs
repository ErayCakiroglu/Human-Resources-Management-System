using HRMS.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Entities.DTOs.Employee
{
    public class DeleteEmployeeDTO : IDTO
    {
        public int Id { get; set; }
        public int TerminationReasonId { get; set; }
        public string? TerminationExplanation { get; set; }
    }
}
