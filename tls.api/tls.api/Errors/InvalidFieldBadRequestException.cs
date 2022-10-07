namespace tls.api.Errors
{
    public sealed class InvalidFieldBadRequestException : BadRequestException
    {
        public InvalidFieldBadRequestException(string field) : base("fields", $"The specified field {field} is not supported.")
        {
        }
    }
}
