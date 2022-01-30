using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Common
{
    public class ExecutionResult<T> : ExecutionResult where T : class
    {
        public T Result { get; protected set; }

        public static ExecutionResult<T> CreateSuccess(T obj) =>
             new ExecutionResult<T>
             {
                 IsSuccess = true,
                 Result = obj,
             };

    }
}
