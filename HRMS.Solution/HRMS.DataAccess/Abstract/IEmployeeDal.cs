using HRMS.Core.DataAccess.Abstract;
using HRMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
    }
}
