using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tls.api.ProductReferences
{
    [Table("ProductReferences")]
    public class ProductReferenceEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(256, ErrorMessage = "Maximum length for the Name is 256 characters.")]
        public string? Name { get; set; }

        public string? ImageUrl { get; set; }
    }
}
