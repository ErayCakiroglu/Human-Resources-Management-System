using HRMS.Business.Helper.Abstract;
using HRMS.DataAccess.Abstract;
using HRMS.Entities.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int count = _employeeDal
                .GetAll(e =>
                    e.FirstName == dto.FirstName &&
                    e.LastName == dto.LastName &&
                    e.DepartmentRoleId == dto.DepartmentRoleId)
                .Count;

            var departmentName = _departmentRoleDal
                .Get(dr => dr.Id == dto.DepartmentRoleId)?
                .Department?.Name ?? "XXX";

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
