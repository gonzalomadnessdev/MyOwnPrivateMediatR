namespace OrdersApi
{
    public interface IFakeService
    {
        Task SendNotification(Guid OrderId);
    }
}