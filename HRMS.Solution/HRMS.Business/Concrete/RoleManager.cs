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
                return new Result(false, "Eklemek istediğiniz rol bulunuyor.");
            }

            _roleDal.Add(role);
            return new Result(true, "Rol eklendi.");
        }

        public Result Delete(Role role)
        {
            var deletedRole = _roleDal.Get(r => r.Id == role.Id);
            if (deletedRole == null)
            {
                return new Result(false, "Silmek istediğiniz rol bulunmuyor");
            }

            deletedRole.IsDeleted = true;
            _roleDal.Update(deletedRole);
            return new Result(true, "Rol silindi.");
        }

        public DataResult<List<Role>> GetAll()
        {
            var roles = _roleDal.GetAll();
            return new DataResult<List<Role>>(roles, true, "Roller listelendi.");
        }

        public DataResult<Role> GetById(int id)
        {
            var role = _roleDal.Get(r => r.Id == id);
            if (role == null)
                return new DataResult<Role>(null, false, "Rol bulunmuyor.");

            return new DataResult<Role>(role, true, "Rol başarıyla getirildi.");
        }

        public Result Update(Role role)
        {
            var updatedRole = _roleDal.Get(r => r.Id == role.Id);
            if (updatedRole == null)
                return new Result(false, "Güncelleme yapılacak rol bulunamadı.");

            updatedRole.IsActive = role.IsActive;
            updatedRole.IsDeleted = role.IsDeleted;
            updatedRole.RoleName = role.RoleName;
            updatedRole.UpdatedAt = DateTime.Now;

            _roleDal.Update(updatedRole);
            return new Result(true, "Rol güncellendi.");
        }
    }
}
