namespace Trading.Common
{
    public class ExecutionResult
    {
        public bool IsSuccess { get; protected set; }
        public string Error { get; protected set; }

<<<<<<< HEAD
        public static ExecutionResult CreateError(string error) =>
            new ExecutionResult
=======
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
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
            {
                Error = error,
                IsSuccess = false
            };
    }
<<<<<<< HEAD
}

=======
}
>>>>>>> 49fbae1b169b8d35e3920b48a9599495e5d661a6
