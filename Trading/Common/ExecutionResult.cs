using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading.Common
{
    public class ExecutionResult
    {
        public bool IsSuccess { get; protected set; }
        public string Error { get; protected set; }

        public static ExecutionResult CreateError(string error) =>
            new ExecutionResult
            {
                Error = error,
                IsSuccess = false
            };
    }
}

