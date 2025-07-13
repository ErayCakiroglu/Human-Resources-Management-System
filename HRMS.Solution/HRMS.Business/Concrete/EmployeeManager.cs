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
            if (_employeeDal.Any(e => e.Email == employee.Email))
                return new Result(false, "This email is already registered.");

            _employeeDal.Add(employee);
            return new Result(true, "The employee was added successfully.");
        }

        public Result Update(Employee employee)
        {
            var updatedEmployee = _employeeDal.Get(e => e.Id == employee.Id);
            if (updatedEmployee == null)
                return new Result(false, "No employees found.");

            updatedEmployee.DepartmentRoleId = employee.DepartmentRoleId;
            updatedEmployee.Email = employee.Email;
            updatedEmployee.FirstName = employee.FirstName;
            updatedEmployee.LastName = employee.LastName;
            updatedEmployee.UpdatedAt = DateTime.Now;
            updatedEmployee.IsActive = employee.IsActive;

            _employeeDal.Update(updatedEmployee);
            return new Result(true, "The worker was updated successfully.");
        }

        public Result Delete(Employee employee)
        {
            var deletedEmployee = _employeeDal.Get(e => e.Id == employee.Id);
            if (deletedEmployee == null)
                return new Result(false, "No employees found.");

            deletedEmployee.IsDeleted = true;
            deletedEmployee.IsActive = false;
            deletedEmployee.UpdatedAt = DateTime.Now;

            _employeeDal.Update(deletedEmployee);
            return new Result(true, "The employee was deleted successfully.");
        }

        public DataResult<Employee> GetById(int id)
        {
            var employee = _employeeDal.Get(e => e.Id == id);
            if (employee == null)
                return new DataResult<Employee>(null, false, "No employees found.");

            return new DataResult<Employee>(employee, true, "The desired employee was brought in.");
        }

        public DataResult<List<Employee>> GetAll()
        {
            var employees = _employeeDal.GetAll();
            return new DataResult<List<Employee>>(employees, true, "The list of employees was brought.");
        }

        public DataResult<List<Employee>> GetAllWithDetails()
        {
            var employees = _employeeDal.GetAllWithDetails();
            return new DataResult<List<Employee>>(employees, true, "The employees were brought in with details.");
        }

    }
}
