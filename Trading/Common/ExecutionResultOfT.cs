using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Common
{
<<<<<<< HEAD
    public class ExecutionResult<T> : ExecutionResult where T : class
    {
        public T Result { get; protected set; }

        public static ExecutionResult<T> CreateSuccess(T obj) =>
             new ExecutionResult<T>
             {
                 IsSuccess = true,
                 Result = obj,
             };

=======
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
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
    }
}
