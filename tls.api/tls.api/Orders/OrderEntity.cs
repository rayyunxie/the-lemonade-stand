using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tls.api.OrderProducts;

namespace tls.api.Orders
{
    [Table("Orders")]
    public class OrderEntity
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Contact is a required field.")]
        [MaxLength(256, ErrorMessage = "Maximum length for the Contact is 256 characters")]
        public string? Contact { get; set; }

        public ICollection<OrderProductEntity>? OrderProducts { get; set; }
    }
}
