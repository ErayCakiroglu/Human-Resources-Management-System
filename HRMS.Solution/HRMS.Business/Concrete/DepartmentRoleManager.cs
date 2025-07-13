using HRMS.Business.Abstract;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Concrete
{
    public class DepartmentRoleManager : IDepartmentRoleService
    {
        private readonly IDepartmentRoleDal _departmentRoleDal;

        public DepartmentRoleManager(IDepartmentRoleDal departmentRoleDal)
        {
            _departmentRoleDal = departmentRoleDal;
        }
        public Result Add(DepartmentRole departmentRole)
        {
            bool addedDepartmentRole = _departmentRoleDal.Any(dr =>
                dr.DepartmentId == departmentRole.DepartmentId &&
                dr.RoleId == departmentRole.RoleId);

            if (addedDepartmentRole)
                return new Result(false, "This department-role combination already exists.");

            _departmentRoleDal.Add(departmentRole);
            return new Result(true, "Department-role successfully added.");
        }

        public Result Update(DepartmentRole departmentRole)
        {
            var updatedDepartmentRole = _departmentRoleDal.Get(dr => dr.Id == departmentRole.Id);
            if (updatedDepartmentRole == null)
                return new Result(false, "Department-role not found.");

            updatedDepartmentRole.UpdatedAt = DateTime.Now;
            updatedDepartmentRole.IsActive = departmentRole.IsActive;

            _departmentRoleDal.Update(updatedDepartmentRole);
            return new Result(true, "Updated.");
        }

        public Result Delete(DepartmentRole departmentRole)
        {
            var deletedDepartmentRole = _departmentRoleDal.Get(dr => dr.Id == departmentRole.Id);
            if (deletedDepartmentRole == null)
                return new Result(false, "Department-role not found.");

            deletedDepartmentRole.IsDeleted = true;
            deletedDepartmentRole.IsActive = false;
            deletedDepartmentRole.UpdatedAt = DateTime.Now;

            _departmentRoleDal.Delete(deletedDepartmentRole);
            return new Result(true, "Deleted.");
        }

        public DataResult<DepartmentRole> GetById(int id)
        {
            var departmentRole = _departmentRoleDal.Get(dr => dr.Id == id);
            if (departmentRole == null)
                return new DataResult<DepartmentRole>(null, false, "Not found.");

            return new DataResult<DepartmentRole>(departmentRole, true, "Success.");
        }

        public DataResult<List<DepartmentRole>> GetAll()
        {
            var departmentRoles = _departmentRoleDal.GetAll();
            return new DataResult<List<DepartmentRole>>(departmentRoles, true, "Listed.");
        }
    }
}
