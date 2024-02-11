namespace SIS.HTTP.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string BadRequestExceptionMessage = "The Request was malformed or contains unsupported elements.";
        public BadRequestException(string msg) : base(msg) { }
        public BadRequestException() : this(BadRequestExceptionMessage) { }
    }
}
