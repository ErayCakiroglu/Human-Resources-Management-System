using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.DepartmentRole;

namespace HRMS.Business.Mapping
{
    public static class DepartmentRoleMapper
    {
        public static DepartmentRoleDetailsDTO ToDetailDto(this DepartmentRole dr) =>
        new()
        {
            Id = dr.Id,
            DepartmentName = dr.Department?.Name ?? string.Empty,
            RoleName = dr.Role?.RoleName ?? string.Empty,
            IsActive = dr.IsActive
        };

        public static DepartmentRole ToEntity(this CreateDepartmentRoleDTO dto) => new()
        {
            DepartmentId = dto.DepartmentId,
            RoleId = dto.RoleId,
            CreatedAt = DateTime.Now,
            IsActive = true,
            IsDeleted = false
        };

        public static void MapToEntity(this UpdateDepartmentRoleDTO dto, DepartmentRole entity)
        {
            if (dto.RoleId.HasValue)
                entity.RoleId = dto.RoleId.Value;

            if (dto.IsActive.HasValue)
                entity.IsActive = dto.IsActive.Value;

            entity.UpdatedAt = DateTime.Now;
        }
    }
}
