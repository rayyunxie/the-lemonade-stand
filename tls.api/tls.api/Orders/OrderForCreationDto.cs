using System.ComponentModel.DataAnnotations;

namespace tls.api.Orders
{
    public record OrderForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Contact is a required field.")]
        [MaxLength(256, ErrorMessage = "Maximum length for the Contact is 256 characters.")]
        public string? Contact { get; init; }

        public IEnumerable<OrderProductDto>? Products { get; init; }
    }
}
