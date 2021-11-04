using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Common
{
    public class ExecutionResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; private set; }
        public string Error { get; private set; }

        public void CreateSuccessResult(T obj) 
        {
            Result = obj;
            IsSuccess = true;
        }

        public void CreateErrorResult(string error)
        {
            Error = error;
            IsSuccess = false;
        }
    }
}
