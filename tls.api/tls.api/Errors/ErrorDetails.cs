using System.Text.Json;

namespace tls.api.Errors
{
    public class ErrorDetails
    {
        public ErrorDetails()
        {
        }

        public ErrorDetails(int status, string name, string error)
        {
            Status = status;
            Errors = new Dictionary<string, string[]> { { name, new string[] { error } } };
        }

        public ErrorDetails(int status, Dictionary<string, string[]> errors)
        {
            Status = status;
            Errors = errors;
        }

        public int Status { get; set; }
        public Dictionary<string, string[]>? Errors { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
    }
}
