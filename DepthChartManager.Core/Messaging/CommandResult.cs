namespace DepthChartManager.Core.Messaging
{
    public class CommandResult<T>
    {
        private CommandResult()
        {
        }

        public CommandResult(T result)
        {
            Result = result;
        }

        public CommandResult(string failureReason)
        {
            FailureReason = failureReason;
        }

        public T Result { get; set; }

        public string FailureReason { get; }

        public bool IsSuccess => string.IsNullOrEmpty(FailureReason);

        public static implicit operator bool(CommandResult<T> result)
        {
            return result.IsSuccess;
        }
    }
}