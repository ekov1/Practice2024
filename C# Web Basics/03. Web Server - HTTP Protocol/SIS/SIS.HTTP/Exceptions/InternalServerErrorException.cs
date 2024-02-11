namespace SIS.HTTP.Exceptions
{
    public class InternalServerErrorException: Exception
    {
        private const string InternalServerErrorExceptionMessage = "The Server has encountered an error.";
        public InternalServerErrorException(string msg) : base(msg) { }
        public InternalServerErrorException() : this(InternalServerErrorExceptionMessage) { }

    }
}
