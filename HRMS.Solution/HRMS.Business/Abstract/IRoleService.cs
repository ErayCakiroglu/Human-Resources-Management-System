using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Abstract
{
    public interface IRoleService
    {
        Result Add(Role employee);
        Result Update(Role employee);
        Result Delete(Role employee);
        DataResult<Role> GetById(int id);
        DataResult<List<Role>> GetAll();
    }
}
