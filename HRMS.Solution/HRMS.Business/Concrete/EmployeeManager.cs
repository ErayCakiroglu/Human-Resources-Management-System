using HRMS.Business.Abstract;
using HRMS.Business.Constants;
using HRMS.Business.Helper.Abstract;
using HRMS.Core.Utilities;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using HRMS.Entities.DTOs.Employee;

namespace HRMS.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly ICodeGenerator<CreateEmployeeDTO> _codeGenerator;

        public EmployeeManager(IEmployeeDal employeeDal, ICodeGenerator<CreateEmployeeDTO> codeGenerator)
        {
            _employeeDal = employeeDal;
            _codeGenerator = codeGenerator;
        }

        public Result Add(CreateEmployeeDTO dto)
        {
            if (_employeeDal.Any(e => e.Email == dto.Email))
                return new Result(false, Messages.IncludesMessage(dto.FirstName + " " + dto.LastName));

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                HireDate = dto.HireDate ?? DateTime.Now,
                DepartmentRoleId = dto.DepartmentRoleId,
                EmployeeCode = _codeGenerator.GenerateCode(dto),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _employeeDal.Add(employee);
            return new Result(true, Messages.AddedMessage(dto.FirstName + " " + dto.LastName));
        }

        public Result Update(UpdateEmployeeDTO dto)
        {
            var updatedEmployee = _employeeDal.Get(e => e.Id == dto.Id);
            if (updatedEmployee == null)
                return new Result(false, Messages.NotFoundMessage("Employee"));

            if (dto.DepartmentRoleId.HasValue)
                updatedEmployee.DepartmentRoleId = dto.DepartmentRoleId.Value;

            if (!string.IsNullOrEmpty(dto.Email))
                updatedEmployee.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.FirstName))
                updatedEmployee.FirstName = dto.FirstName;

            if (!string.IsNullOrEmpty(dto.LastName))
                updatedEmployee.LastName = dto.LastName;

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
                updatedEmployee.PhoneNumber = dto.PhoneNumber;

            if (dto.HireDate.HasValue)
                updatedEmployee.HireDate = dto.HireDate.Value;

            updatedEmployee.UpdatedAt = DateTime.Now;

            _employeeDal.Update(updatedEmployee);
            return new Result(true, Messages.UpdatedMessage(dto.FirstName + " " + dto.LastName));
        }

        public Result Delete(DeleteEmployeeDTO dto)
        {
            var employee = _employeeDal.Get(e => e.Id == dto.Id);
            if (employee == null)
                return new Result(false, Messages.NotFoundMessage("Employee"));

            employee.IsActive = false;
            employee.IsDeleted = true;
            employee.TerminationReasonId = dto.TerminationReasonId;
            employee.TerminationExplanation = dto.TerminationExplanation;
            employee.TerminationDate = DateTime.Now;
            employee.UpdatedAt = DateTime.Now;

            _employeeDal.Update(employee);
            return new Result(true, Messages.DeletedMessage(dto.FirstName + " " + dto.LastName));
        }


        public DataResult<EmployeeDetailDTO> GetById(int id)
        {
            var employee = _employeeDal.Get(e => e.Id == id);
            if (employee == null)
                return new DataResult<EmployeeDetailDTO>(null, false, Messages.NotFoundMessage("Employee"));

            var dto = new EmployeeDetailDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HireDate = employee.HireDate,
                EmployeeCode = employee.EmployeeCode,
                DepartmentRoleId = employee.DepartmentRoleId,
                DepartmentName = employee.DepartmentRole?.Department?.Name ?? "",
                RoleName = employee.DepartmentRole?.Role?.RoleName ?? "",
                IsActive = employee.IsActive,
                IsDeleted = employee.IsDeleted,
                CreatedAt = employee.CreatedAt,
                UpdatedAt = employee.UpdatedAt
            };

            return new DataResult<EmployeeDetailDTO>(dto, true, Messages.WasBroughtMessage(dto.FirstName + " " +
                dto.LastName));
        }

        public DataResult<List<EmployeeSummaryDTO>> GetAll()
        {
            var employees = _employeeDal.GetAll();

            var employeeDtos = employees.Select(employee => new EmployeeSummaryDTO
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                EmployeeCode = employee.EmployeeCode,
                DepartmentName = employee.DepartmentRole?.Department?.Name ?? "",
                RoleName = employee.DepartmentRole?.Role?.RoleName ?? "",
            }).ToList();

            return new DataResult<List<EmployeeSummaryDTO>>(employeeDtos, true, Messages.ListedMessage("Employees"));
        }

        public DataResult<List<EmployeeDetailDTO>> GetAllWithDetails()
        {
            var employees = _employeeDal.GetAllWithDetails();

            var employeeDetails = employees.Select(e => new EmployeeDetailDTO
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                HireDate = e.HireDate,
                EmployeeCode = e.EmployeeCode,
                DepartmentRoleId = e.DepartmentRoleId,
                DepartmentName = e.DepartmentRole?.Department?.Name ?? "",
                RoleName = e.DepartmentRole?.Role?.RoleName ?? "",
                IsActive = e.IsActive,
                IsDeleted = e.IsDeleted,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            }).ToList();

            return new DataResult<List<EmployeeDetailDTO>>(employeeDetails, true,
                Messages.WithDetailsMessage("Employees"));
        }
    }
}
