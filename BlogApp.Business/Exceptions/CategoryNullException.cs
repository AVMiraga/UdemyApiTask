namespace BlogApp.Business.Exceptions
{
    public class CategoryNullException : Exception
    {
        public CategoryNullException()
        {
        }

        public CategoryNullException(string? message) : base(message)
        {
        }
    }
}
