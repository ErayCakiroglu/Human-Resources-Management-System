using HRMS.Business.Abstract;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Concrete
{
    public class DepartmentRelationManager : IDepartmentRelationService
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly IDepartmentRoleDal _departmentRoleDal;

        public DepartmentRelationManager(IEmployeeDal employeeDal, IDepartmentRoleDal departmentRoleDal)
        {
            _employeeDal = employeeDal;
            _departmentRoleDal = departmentRoleDal;
        }
        public Result AssignEmployeeToRole(int employeeId, int departmentRoleId)
        {
            var employee = _employeeDal.Get(e => e.Id == employeeId);
            if (employee == null)
                return new Result(false, "Çalışan bulunamadı");

            var departmentRole = _departmentRoleDal.Get(dr => dr.Id == departmentRoleId);
            if (departmentRole == null)
                return new Result(false, "Departman rolü bulunamadı");

            employee.DepartmentRoleId = departmentRoleId;
            _employeeDal.Update(employee);

            return new Result(true, "Çalışan başarıyla departman rolüne atandı.");
        }

        public Result AssignRolesToDepartment(int departmentId, List<int> roleIds)
        {
            foreach (var roleId in roleIds)
            {
                var exists = _departmentRoleDal.Get(dr =>
                    dr.RoleId == roleId && dr.DepartmentId == departmentId && !dr.IsDeleted);

                if (exists != null)
                    continue;

                _departmentRoleDal.Add(new DepartmentRole
                {
                    DepartmentId = departmentId,
                    RoleId = roleId,
                    IsDeleted = false,
                    CreatedAt = DateTime.Now
                });
            }

            return new Result(true, "Roller departmana başarıyla atandı.");
        }
    }
}
