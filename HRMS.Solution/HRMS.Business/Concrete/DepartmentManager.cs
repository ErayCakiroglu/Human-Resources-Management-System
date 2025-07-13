using HRMS.Business.Abstract;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public Result Add(Department department)
        {
            if (_departmentDal.Any(d => d.Name == department.Name))
                return new Result(false, "There is a department with this department name.");

            _departmentDal.Add(department);
            return new Result(true, "Department added successfully.");
        }

        public Result Delete(Department department)
        {
            var deletedDepartment = _departmentDal.Get(d => d.Id == department.Id);

            if (deletedDepartment == null)
                return new Result(false, "Department not found.");

            deletedDepartment.IsActive = false;
            deletedDepartment.IsDeleted = true;
            deletedDepartment.UpdatedAt = DateTime.Now;

            _departmentDal.Update(deletedDepartment);
            return new Result(true, "The department was deleted successfully.");
        }

        public DataResult<List<Department>> GetAll()
        {
            var departments = _departmentDal.GetAll();
            return new DataResult<List<Department>>(departments, true, "All departments listed.");
        }

        public DataResult<Department> GetById(int id)
        {
            var department = _departmentDal.Get(d => d.Id == id);

            if (department == null)
                return new DataResult<Department>(null, false, "Department not found.");

            return new DataResult<Department>(department, true, "The department was brought successfully.");
        }

        public Result Update(Department department)
        {
            var updatedDepartment = _departmentDal.Get(d => d.Id == department.Id);

            if (updatedDepartment == null)
                return new Result(false, "No department found to update.");

            updatedDepartment.IsActive = department.IsActive;
            updatedDepartment.Name = department.Name;
            updatedDepartment.UpdatedAt = DateTime.Now;

            _departmentDal.Update(updatedDepartment);
            return new Result(true, "Department updated.");
        }
    }
}
