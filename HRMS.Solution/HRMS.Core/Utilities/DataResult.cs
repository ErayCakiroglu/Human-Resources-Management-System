using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Core.Utilities
{
    public class DataResult<T> : Result
    {
        public T? Data { get; }

        public DataResult(T? data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }
}
