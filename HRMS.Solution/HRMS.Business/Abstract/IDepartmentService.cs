using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Abstract
{
    public interface IDepartmentService
    {
        Result Add(Department employee);
        Result Update(Department employee);
        Result Delete(Department employee);
        DataResult<Department> GetById(int id);
        DataResult<List<Department>> GetAll();
    }
}
