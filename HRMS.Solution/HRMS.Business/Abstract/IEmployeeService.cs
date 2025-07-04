using HRMS.Core.Utilities;
using HRMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Abstract
{
    public interface IEmployeeService
    {
        Result Add(Employee employee);
        Result Update(Employee employee);
        Result Delete(Employee employee);
        DataResult<Employee> GetById(int id);
        DataResult<List<Employee>> GetAll();
    }
}
