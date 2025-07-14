using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Employee;

namespace HRMS.Business.Abstract
{
    public interface IEmployeeService
    {
        Result Add(CreateEmployeeDTO createdEmployeeDto);
        Result Update(UpdateEmployeeDTO updatedEmployeeDto);
        Result Delete(DeleteEmployeeDTO deletedEmployeeDto);
        DataResult<EmployeeDetailDTO> GetById(int id);
        DataResult<List<EmployeeSummaryDTO>> GetAll();
        DataResult<List<EmployeeDetailDTO>> GetAllWithDetails();
    }
}
