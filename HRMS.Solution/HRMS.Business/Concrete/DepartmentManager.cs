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
                return new Result(false, "Bu departman adına sahip departman bulunuyor.");

            _departmentDal.Add(department);
            return new Result(true, "Departman başarıyla eklendi.");
        }

        public Result Delete(Department department)
        {
            var existingDepartment = _departmentDal.Get(d => d.Id == department.Id);

            if (existingDepartment == null)
                return new Result(false, "Departman bulunamadı.");

            existingDepartment.IsActive = false;
            _departmentDal.Update(existingDepartment);
            return new Result(true, "Departman başarıyla silindi.");
        }

        public DataResult<List<Department>> GetAll()
        {
            var departments = _departmentDal.GetAll();
            return new DataResult<List<Department>>(departments, true, "Başarılı.");
        }

        public DataResult<Department> GetById(int id)
        {
            var department = _departmentDal.Get(d => d.Id == id);

            if (department == null)
                return new DataResult<Department>(null, false, "Departman bulunamadı.");

            return new DataResult<Department>(department, true, "Departman başarıyla getirildi.");
        }

        public Result Update(Department department)
        {
            var updatedDepartment = _departmentDal.Get(d => d.Id == department.Id);

            if (updatedDepartment == null)
                return new Result(false, "Güncellenecek departman bulunamadı.");

            updatedDepartment.IsActive = department.IsActive;
            updatedDepartment.IsDeleted = department.IsDeleted;
            updatedDepartment.Name = department.Name;
            updatedDepartment.UpdatedAt = DateTime.Now;

            _departmentDal.Update(updatedDepartment);
            return new Result(true, "Departman güncellendi.");
        }
    }
}
