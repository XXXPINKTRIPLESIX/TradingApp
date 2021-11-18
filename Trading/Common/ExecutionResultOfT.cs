using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Common
{
    public class ExecutionResult<T> : ExecutionResult
    {
        public T Result { get; private set; }

        public static ExecutionResult<T> CreateSuccessResult(T obj)
        {
            return new ExecutionResult<T>
            {
                Result = obj,
                IsSuccess = true
            };
        }

        public new static ExecutionResult<T> CreateErrorResult(string error)
        {
            return new ExecutionResult<T>
            {
                Error = error,
                IsSuccess = false
            };
        }
    }
}
