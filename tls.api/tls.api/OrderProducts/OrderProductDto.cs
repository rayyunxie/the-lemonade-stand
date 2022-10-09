using System.ComponentModel.DataAnnotations;

namespace tls.api.OrderProducts
{
    public record OrderProductDto
    {
        [Required(ErrorMessage = "ProductId is a required field.")]
        public Guid? ProductId { get; init; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to {1}")]
        public int Quantity { get; init; }
        [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be greater than or equal to {1}")]
        public double UnitPrice { get; init; }
    }
}
