namespace tls.api.Errors
{
    public abstract class NotFoundException : BaseException
    {
        protected NotFoundException(string name, string message) : base(name, message)
        {
        }
    }
}
