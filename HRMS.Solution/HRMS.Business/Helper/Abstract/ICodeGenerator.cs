using HRMS.Entities.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Business.Helper.Abstract
{
    public interface ICodeGenerator<T>
    {
        string GenerateCode(T TDto);
    }
}
