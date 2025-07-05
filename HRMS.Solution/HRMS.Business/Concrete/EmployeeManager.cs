using HRMS.Business.Abstract;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public Result Add(Employee employee)
        {
            // İş kuralı: Aynı e-posta olamaz
            if (_employeeDal.Any(e => e.Email == employee.Email))
                return new Result(false, "Bu e-posta zaten kayıtlı.");

            // Diğer kurallar burada olur

            _employeeDal.Add(employee);
            return new Result(true, "Çalışan başarıyla eklendi.");
        }

        public Result Update(Employee employee)
        {
            var existingEmployee = _employeeDal.Get(e => e.Id == employee.Id);
            if (existingEmployee == null)
                return new Result(false, "Çalışan bulunamadı.");

            // Güncelleme kuralları burada

            _employeeDal.Update(employee);
            return new Result(true, "Çalışan başarıyla güncellendi.");
        }

        public Result Delete(Employee employee)
        {
            var existingEmployee = _employeeDal.Get(e => e.Id == employee.Id);
            if (existingEmployee == null)
                return new Result(false, "Çalışan bulunamadı.");

            _employeeDal.Delete(employee);
            return new Result(true, "Çalışan başarıyla silindi.");
        }

        public DataResult<Employee> GetById(int id)
        {
            var employee = _employeeDal.Get(e => e.Id == id);
            if (employee == null)
                return new DataResult<Employee>(null, false, "Çalışan bulunamadı.");

            return new DataResult<Employee>(employee, true, "Başarılı.");
        }

        public DataResult<List<Employee>> GetAll()
        {
            var employees = _employeeDal.GetAll();
            return new DataResult<List<Employee>>(employees, true, "Başarılı.");
        }

        public DataResult<List<Employee>> GetAllWithDetails()
        {
            var employees = _employeeDal.GetAllWithDetails();
            return new DataResult<List<Employee>>(employees, true, "Çalışanlar detaylarıyla getirildi.");
        }

    }
}
