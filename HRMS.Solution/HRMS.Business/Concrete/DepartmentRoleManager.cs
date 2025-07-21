using HRMS.Business.Abstract;
using HRMS.Business.Constants;
using HRMS.Business.Mapping;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Abstract;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.DepartmentRole;
using System.Data;

namespace HRMS.Business.Concrete
{
    public class DepartmentRoleManager : IDepartmentRoleService
    {
        private readonly IDepartmentRoleDal _departmentRoleDal;

        public DepartmentRoleManager(IDepartmentRoleDal departmentRoleDal)
        {
            _departmentRoleDal = departmentRoleDal;
        }
        public Result Add(CreateDepartmentRoleDTO departmentRoleDTO)
        {
            if (_departmentRoleDal.Any(dr => dr.DepartmentId == departmentRoleDTO.DepartmentId &&
                                             dr.RoleId == departmentRoleDTO.RoleId &&
                                             !dr.IsDeleted))
                return new Result(false, Messages.AlreadyExistsMessage($"DepartmentId: {departmentRoleDTO.DepartmentId}," +
                    $"RoleId: {departmentRoleDTO.RoleId}"));

            var entity = departmentRoleDTO.ToEntity();
            _departmentRoleDal.Add(entity);

            return new Result(true, Messages.AddedMessage($"DepartmentId: {departmentRoleDTO.DepartmentId}," +
                $"RoleId: {departmentRoleDTO.RoleId}"));
        }

        public Result Update(UpdateDepartmentRoleDTO departmentRoleDTO)
        {
            var entity = _departmentRoleDal.Get(dr => dr.Id == departmentRoleDTO.Id);
            if (entity == null)
                return new Result(false, Messages.NotFoundMessage($"DepartmentRole Id: {departmentRoleDTO.Id}"));

            departmentRoleDTO.MapToEntity(entity);
            _departmentRoleDal.Update(entity);

            return new Result(true, Messages.UpdatedMessage($"DepartmentRole Id: {departmentRoleDTO.Id}"));
        }

        public Result Delete(DeleteDepartmentRoleDTO departmentRoleDTO)
        {
            var entity = _departmentRoleDal.GetWithDepartmentAndRole(departmentRoleDTO.Id);

            if (entity == null)
                return new Result(false, Messages.NotFoundMessage($"DepartmentRole Id: {departmentRoleDTO.Id}"));

            entity.IsDeleted = true;
            entity.IsActive = false;
            entity.UpdatedAt = DateTime.Now;

            _departmentRoleDal.Update(entity);
            return new Result(true, Messages.DeletedMessage(entity.Department?.Name ?? ""));
        }

        public DataResult<DepartmentRoleDetailsDTO> GetById(int id)
        {
            var entity = _departmentRoleDal.GetWithDepartmentAndRole(id);
            if (entity == null)
                return new DataResult<DepartmentRoleDetailsDTO>(null, false,
                    Messages.NotFoundMessage($"DepartmentRole Id: {id}"));

            return new DataResult<DepartmentRoleDetailsDTO>(entity.ToDetailDto(), true,
                Messages.WasBroughtMessage(entity.Department?.Name ?? ""));
        }

        public DataResult<List<DepartmentRoleDetailsDTO>> GetAllDetails()
        {
            var dtos = _departmentRoleDal
                .GetAllWithDetails()
                .Select(dr => dr.ToDetailDto())
                .ToList();

            return new DataResult<List<DepartmentRoleDetailsDTO>>(dtos, true,
                Messages.ListedMessage("Departments-role listed"));
        }
    }
}
