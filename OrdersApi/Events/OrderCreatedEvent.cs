namespace OrdersApi.Events
{
    public record OrderCreatedEvent(Guid OrderId, DateTime Date);
}
