using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Department;

namespace HRMS.Business.Abstract
{
    public interface IDepartmentService
    {
        Result Add(CreateDepartmentDTO employee);
        Result Update(UpdateDepartmentDTO employee);
        Result Delete(DeleteDepartmentDTO employee);
        DataResult<DepartmentDetailsDTO> GetById(int id);
        DataResult<List<DepartmentDetailsDTO>> GetAll();
        DataResult<List<DepartmentDetailsDTO>> GetAllWithDetail();

    }
}
