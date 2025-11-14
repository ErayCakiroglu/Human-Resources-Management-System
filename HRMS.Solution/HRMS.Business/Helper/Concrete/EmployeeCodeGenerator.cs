using HRMS.Business.Helper.Abstract;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.DTOs.Employee;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Business.Helper.Concrete
{
    public class EmployeeCodeGenerator : ICodeGenerator<CreateEmployeeDTO>
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly IDepartmentRoleDal _departmentRoleDal;

        public EmployeeCodeGenerator(IEmployeeDal employeeDal, IDepartmentRoleDal departmentRoleDal)
        {
            _employeeDal = employeeDal;
            _departmentRoleDal = departmentRoleDal;
        }

        public string GenerateCode(CreateEmployeeDTO dto)
        {
            if (!dto.DepartmentRoleId.HasValue)
            {
                var initialsFallback = $"{dto.FirstName[0]}{dto.LastName[0]}".ToUpper();
                var yearFallback = dto.HireDate?.Year ?? DateTime.Now.Year;
                return $"{initialsFallback}-NODEP-{yearFallback}001";
            }

            var departmentRole = _departmentRoleDal.Get(
                dr => dr.Id == dto.DepartmentRoleId.Value,
                include: query => query.Include(dr => dr.Department)
            );

            var departmentName = departmentRole?.Department?.Name ?? "UNKNOWN";

            int count = _employeeDal
                .GetAll(e => e.FirstName == dto.FirstName && e.LastName == dto.LastName)
                .Count;


            var initials = $"{dto.FirstName[0]}{dto.LastName[0]}".ToUpper();
            var departmentCode = departmentName.Length >= 3
                ? departmentName.Substring(0, 3).ToUpper()
                : departmentName.ToUpper();

            var year = dto.HireDate?.Year ?? DateTime.Now.Year;
            var sequence = (count + 1).ToString("D3");

            return $"{initials}-{departmentCode}-{year}{sequence}";
        }
    }
}
