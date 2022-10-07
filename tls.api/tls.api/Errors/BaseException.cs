namespace tls.api.Errors
{
    public abstract class BaseException : Exception
    {
        public string Name { get; set; }

        protected BaseException(string name, string message) : base(message)
        {
            Name = name;
        }
    }
}
