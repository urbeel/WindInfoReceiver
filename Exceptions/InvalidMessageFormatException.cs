namespace PortsApp.Exception
{
    public class InvalidMessageFormatException : System.Exception
    {
        public InvalidMessageFormatException() { }

        public InvalidMessageFormatException(string? message)
            : base(message)
        {
        }

        public InvalidMessageFormatException(string? message, System.Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}
