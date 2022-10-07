namespace tls.api.Errors
{
    public sealed class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid orderId) :
            base("Order.Id", $"The order with id {orderId} doesn't exist.")
        {
        }
    }
}
