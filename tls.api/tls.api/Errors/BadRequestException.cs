namespace tls.api.Errors
{
    public abstract class BadRequestException : BaseException
    {
        protected BadRequestException(string name, string message) : base(name, message)
        {
        }
    }
}
