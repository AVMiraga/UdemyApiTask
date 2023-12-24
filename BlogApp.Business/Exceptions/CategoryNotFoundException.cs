namespace BlogApp.Business.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        public CategoryNotFoundException()
        {
        }

        public CategoryNotFoundException(string? message) : base(message)
        {
        }
    }
}
