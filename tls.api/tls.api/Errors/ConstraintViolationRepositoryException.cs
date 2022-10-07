namespace tls.api.Errors
{
    public sealed class ConstraintViolationRepositoryException : BaseException
    {
        public ConstraintViolationRepositoryException() : base("DbUpdate",
                    "Constraint violation while updating database")
        {
        }
    }
}
