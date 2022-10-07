using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tls.api.OrderProducts;
using tls.api.ProductReferences;

namespace tls.api.Products
{
    [Table("Products")]
    public class ProductEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [ForeignKey(nameof(ProductReference))]
        public Guid ProductReferenceId { get; set; }
        public ProductReferenceEntity? ProductReference { get; set; }

        // If provided, this overwrites ProductReference's ImageUrl
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "SizeName is a required field.")]
        [MaxLength(256, ErrorMessage = "Maximum length for the SizeName is 256 characters.")]
        public string? SizeName { get; set; }

        public int SizeValue { get; set; }

        public double Price { get; set; }

        public ICollection<OrderProductEntity>? OrderProducts { get; set; }
    }
}
