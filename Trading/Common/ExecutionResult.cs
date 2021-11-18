namespace Trading.Common
{
    public class ExecutionResult
    {
        public bool IsSuccess { get; protected set; }
        public string Error { get; protected set; }

        public static ExecutionResult CreateSuccessResult()
        {
            return new ExecutionResult
            {
                IsSuccess = true
            };
        }

        public static ExecutionResult CreateErrorResult(string error)
        {
            return new ExecutionResult
            {
                Error = error,
                IsSuccess = false
            };
        }
    }
}