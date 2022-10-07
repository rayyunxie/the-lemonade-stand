using System.ComponentModel.DataAnnotations.Schema;
using tls.api.Orders;
using tls.api.Products;

namespace tls.api.OrderProducts
{
    [Table("OrderProducts")]
    public class OrderProductEntity
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public OrderEntity? Order { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
