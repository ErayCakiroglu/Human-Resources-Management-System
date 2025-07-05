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
            bool exists = _departmentRoleDal.Any(dr =>
                dr.DepartmentId == departmentRole.DepartmentId &&
                dr.RoleId == departmentRole.RoleId);

            if (exists)
                return new Result(false, "This department-role combination already exists.");

            _departmentRoleDal.Add(departmentRole);
            return new Result(true, "Department-role successfully added.");
        }

        public Result Update(DepartmentRole departmentRole)
        {
            var existing = _departmentRoleDal.Get(dr => dr.Id == departmentRole.Id);
            if (existing == null)
                return new Result(false, "Department-role not found.");

            _departmentRoleDal.Update(departmentRole);
            return new Result(true, "Updated.");
        }

        public Result Delete(DepartmentRole departmentRole)
        {
            var existing = _departmentRoleDal.Get(dr => dr.Id == departmentRole.Id);
            if (existing == null)
                return new Result(false, "Department-role not found.");

            _departmentRoleDal.Delete(departmentRole);
            return new Result(true, "Deleted.");
        }

        public DataResult<DepartmentRole> GetById(int id)
        {
            var dr = _departmentRoleDal.Get(dr => dr.Id == id);
            if (dr == null)
                return new DataResult<DepartmentRole>(null, false, "Not found.");

            return new DataResult<DepartmentRole>(dr, true, "Success.");
        }

        public DataResult<List<DepartmentRole>> GetAll()
        {
            var list = _departmentRoleDal.GetAll();
            return new DataResult<List<DepartmentRole>>(list, true, "Listed.");
        }
    }
}
