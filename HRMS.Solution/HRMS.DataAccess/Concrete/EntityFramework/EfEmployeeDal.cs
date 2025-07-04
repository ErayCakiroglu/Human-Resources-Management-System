using HRMS.DataAccess.Abstract;
using HRMS.DataAccess.Repositories;
using HRMS.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal(HRMSDbContext context) : EfEntityRepositoryBase<Employee,
        HRMSDbContext>(context), IEmployeeDal
    {
    }
}
