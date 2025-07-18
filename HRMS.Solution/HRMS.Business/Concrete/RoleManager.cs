using HRMS.Business.Abstract;
using HRMS.Business.Constants;
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
                return new Result(false, Messages.IncludesMessage(role.RoleName));
            }

            _roleDal.Add(role);
            return new Result(true, Messages.AddedMessage(role.RoleName));
        }

        public Result Delete(Role role)
        {
            var deletedRole = _roleDal.Get(r => r.Id == role.Id);
            if (deletedRole == null)
            {
                return new Result(false, Messages.NotFoundMessage("Role"));
            }

            deletedRole.IsDeleted = true;
            deletedRole.IsActive = false;
            deletedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(deletedRole);
            return new Result(true, Messages.DeletedMessage(role.RoleName));
        }

        public DataResult<List<Role>> GetAll()
        {
            var roles = _roleDal.GetAll();
            return new DataResult<List<Role>>(roles, true, Messages.ListedMessage("Roles"));
        }

        public DataResult<Role> GetById(int id)
        {
            var role = _roleDal.Get(r => r.Id == id);
            if (role == null)
                return new DataResult<Role>(null, false, Messages.NotFoundMessage("Role"));

            return new DataResult<Role>(role, true, Messages.WasBroughtMessage(role.RoleName));
        }

        public Result Update(Role role)
        {
            var updatedRole = _roleDal.Get(r => r.Id == role.Id);
            if (updatedRole == null)
                return new Result(false, Messages.NotFoundMessage(role.RoleName));

            updatedRole.IsActive = role.IsActive;
            updatedRole.RoleName = role.RoleName;
            updatedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(updatedRole);
            return new Result(true, Messages.UpdatedMessage(role.RoleName));
        }
    }
}
