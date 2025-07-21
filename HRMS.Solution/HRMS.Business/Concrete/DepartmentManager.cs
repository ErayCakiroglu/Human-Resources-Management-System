using HRMS.Business.Abstract;
using HRMS.Business.Constants;
using HRMS.Business.Mapping;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Department;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public Result Add(CreateDepartmentDTO departmentDTO)
        {
            if (_departmentDal.Any(d => d.Name == departmentDTO.Name && !d.IsDeleted))
                return new Result(false, Messages.AlreadyExistsMessage(departmentDTO.Name));

            var newDepartment = new Department
            {
                Name = departmentDTO.Name,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            _departmentDal.Add(newDepartment);

            return new Result(true, Messages.AddedMessage(newDepartment.Name));
        }

        public Result Update(UpdateDepartmentDTO department)
        {
            var updatedDepartment = _departmentDal.Get(d => d.Id == department.Id && !d.IsDeleted);

            if (updatedDepartment == null)
                return new Result(false, Messages.NotFoundMessage("Department"));

            if (!string.IsNullOrEmpty(department.Name))
                updatedDepartment.Name = department.Name;

            if (department.IsActive.HasValue)
                updatedDepartment.IsActive = department.IsActive.Value;

            updatedDepartment.UpdatedAt = DateTime.Now;

            _departmentDal.Update(updatedDepartment);

            return new Result(true, Messages.UpdatedMessage(updatedDepartment.Name));
        }

        public Result Delete(DeleteDepartmentDTO department)
        {
            var deletedDepartment = _departmentDal.Get(d => d.Id == department.Id && !d.IsDeleted);

            if (deletedDepartment == null)
                return new Result(false, Messages.NotFoundMessage("Department"));

            deletedDepartment.IsActive = false;
            deletedDepartment.IsDeleted = true;
            deletedDepartment.DeletedBy = department.DeletedBy;
            deletedDepartment.DeletionReason = department.Reason;
            deletedDepartment.UpdatedAt = DateTime.Now;

            _departmentDal.Update(deletedDepartment);

            return new Result(true, Messages.DeletedMessage(deletedDepartment.Name));
        }

        public DataResult<List<DepartmentDetailsDTO>> GetAll()
        {
            var departments = _departmentDal.GetAll(d => !d.IsDeleted);

            var departmentDtos = departments.Select(DepartmentMapper.MapToDetailsDTO).ToList();

            return new DataResult<List<DepartmentDetailsDTO>>(departmentDtos, true,
                Messages.ListedMessage("Departments"));
        }

        public DataResult<DepartmentDetailsDTO> GetById(int id)
        {
            var department = _departmentDal.Get(
                d => d.Id == id && !d.IsDeleted,
                include: query => query
                    .Include(d => d.DepartmentRoles.Where(dr => !dr.IsDeleted))
                        .ThenInclude(dr => dr.Role)
                    .Include(d => d.DepartmentRoles.Where(dr => !dr.IsDeleted))
                        .ThenInclude(dr => dr.Employees.Where(e => !e.IsDeleted))
            );

            if (department == null)
                return new DataResult<DepartmentDetailsDTO>(null, false, Messages.NotFoundMessage("Department"));

            var dto = DepartmentMapper.MapToDetailsDTO(department);

            return new DataResult<DepartmentDetailsDTO>(dto, true, Messages.WasBroughtMessage(department.Name));
        }
    }
}
