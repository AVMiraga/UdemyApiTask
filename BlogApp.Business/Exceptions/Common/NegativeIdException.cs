namespace BlogApp.Business.Exceptions.Common
{
    public class NegativeIdException : Exception
    {
        public NegativeIdException()
        {
        }

        public NegativeIdException(string? message) : base(message)
        {
        }
    }
}
