using HRMS.Core.Utilities;
using HRMS.Entities.DTOs.Department;

namespace HRMS.Business.Abstract
{
    public interface IDepartmentService
    {
        Result Add(CreateDepartmentDTO departmentDTO);
        Result Update(UpdateDepartmentDTO department);
        Result Delete(DeleteDepartmentDTO department);

        DataResult<DepartmentDetailsDTO> GetById(int id);
        DataResult<List<DepartmentDetailsDTO>> GetAll();
        DataResult<List<DepartmentDetailsDTO>> GetAllWithDetail();
    }
}