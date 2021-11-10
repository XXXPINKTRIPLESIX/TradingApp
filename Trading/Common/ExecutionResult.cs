using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Common
{
    public class ExecutionResult<T>
    {
        public bool IsSuccess { get; private set; }
        public T Result { get; private set; }
        public string Error { get; private set; }

        public static ExecutionResult<T> CreateSuccessResult(T obj)
        {
            return new ExecutionResult<T>
            {
                Result = obj,
                IsSuccess = true
            };
        }

        public static ExecutionResult<T> CreateErrorResult(string error)
        {
            return new ExecutionResult<T>
            {
                Error = error,
                IsSuccess = false
            };
        }
    }
}
