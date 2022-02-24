namespace Akvelon.TaskTracker.BusinessLogicLayer.Exceptions;

    /// <summary>
    /// Custom exception for invalid date
    /// </summary>
    public class InvalidDateTimeException : Exception
    {
        public InvalidDateTimeException(string message) : base(message)
        {
        }
    }