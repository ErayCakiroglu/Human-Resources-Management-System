using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Abstract
{
    public interface IEmployeeService
    {
        Result Add(Employee employee);
        Result Update(Employee employee);
        Result Delete(Employee employee);
        DataResult<Employee> GetById(int id);
        DataResult<List<Employee>> GetAll();
        DataResult<List<Employee>> GetAllWithDetails();
    }
}
