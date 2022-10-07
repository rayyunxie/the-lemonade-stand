using System.ComponentModel.DataAnnotations;

namespace tls.api.Orders
{
    public record OrderForCreationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters.")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Company country is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Country is 40 characters.")]
        public string? Country { get; init; }
    }
}
