using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Utilities
{
    public class Result
    {
        public bool Success { get; }
        public string Message { get; }

        public Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
