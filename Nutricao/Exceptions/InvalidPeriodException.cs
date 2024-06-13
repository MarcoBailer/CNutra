namespace Nutricao.Exceptions
{
    public class InvalidPeriodException : Exception
    {
        public InvalidPeriodException() { }

        public InvalidPeriodException(string message) : base(message) { }

        public InvalidPeriodException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
