using HRMS.Business.Abstract;
using HRMS.Business.Constants;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Concrete
{
    public class DepartmentRelationManager : IDepartmentRelationService
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly IDepartmentRoleDal _departmentRoleDal;
        private readonly IEmployeeDepartmentRoleDal _employeeDepartmentRoleDal;

        public DepartmentRelationManager(IEmployeeDal employeeDal,
                                         IDepartmentRoleDal departmentRoleDal,
                                         IEmployeeDepartmentRoleDal employeeDepartmentRoleDal)
        {
            _employeeDal = employeeDal;
            _departmentRoleDal = departmentRoleDal;
            _employeeDepartmentRoleDal = employeeDepartmentRoleDal;
        }

        public Result AssignEmployeeToRole(int employeeId, int departmentRoleId)
        {
            var employee = _employeeDal.Get(e => e.Id == employeeId);
            if (employee == null)
                return new Result(false, Messages.NotFoundMessage("Employee"));

            var departmentRole = _departmentRoleDal.Get(dr => dr.Id == departmentRoleId);
            if (departmentRole == null)
                return new Result(false, Messages.NotFoundMessage("Department-Role"));

            var exists = _employeeDepartmentRoleDal.Get(edr =>
                edr.EmployeeId == employeeId &&
                edr.DepartmentId == departmentRole.DepartmentId &&
                edr.RoleId == departmentRole.RoleId &&
                !edr.IsDeleted);

            if (exists != null)
                return new Result(false, Messages.AlreadyExistsMessage("Employee assignment to this department role"));


            var newAssignment = new EmployeeDepartmentRole
            {
                EmployeeId = employeeId,
                DepartmentId = departmentRole.DepartmentId,
                RoleId = departmentRole.RoleId,
            };

            _employeeDepartmentRoleDal.Add(newAssignment);

            return new Result(true, Messages.AppointMessage("Employee to department role"));
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
                });
            }

            return new Result(true, Messages.AppointMessage("Roles to department"));
        }
    }
}