using HRMS.Business.Abstract;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;

namespace HRMS.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public Result Add(Role role)
        {
            if (_roleDal.Any(r => r.RoleName == role.RoleName))
            {
                return new Result(false, "There is a job role you want to add.");
            }

            _roleDal.Add(role);
            return new Result(true, "Job role added.");
        }

        public Result Delete(Role role)
        {
            var deletedRole = _roleDal.Get(r => r.Id == role.Id);
            if (deletedRole == null)
            {
                return new Result(false, "The job role you want to delete does not exist.");
            }

            deletedRole.IsDeleted = true;
            deletedRole.IsActive = false;
            deletedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(deletedRole);
            return new Result(true, "The job role was deleted.");
        }

        public DataResult<List<Role>> GetAll()
        {
            var roles = _roleDal.GetAll();
            return new DataResult<List<Role>>(roles, true, "All roles are listed.");
        }

        public DataResult<Role> GetById(int id)
        {
            var role = _roleDal.Get(r => r.Id == id);
            if (role == null)
                return new DataResult<Role>(null, false, "The job role you want is not available.");

            return new DataResult<Role>(role, true, "The job role you requested has been successfully filled.");
        }

        public Result Update(Role role)
        {
            var updatedRole = _roleDal.Get(r => r.Id == role.Id);
            if (updatedRole == null)
                return new Result(false, "No job role found to update.");

            updatedRole.IsActive = role.IsActive;
            updatedRole.RoleName = role.RoleName;
            updatedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(updatedRole);
            return new Result(true, "The job role has been updated.");
        }
    }
}
