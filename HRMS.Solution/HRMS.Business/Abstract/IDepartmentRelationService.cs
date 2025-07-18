using HRMS.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Abstract
{
    public interface IDepartmentRelationService
    {
        Result AssignEmployeeToRole(int employeeId, int departmentRoleId);
        Result AssignRolesToDepartment(int departmentId, List<int> roleIds);
    }
}
