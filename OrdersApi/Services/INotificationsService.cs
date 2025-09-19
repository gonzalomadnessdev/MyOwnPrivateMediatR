namespace OrdersApi.Services
{
    public interface INotificationsService
    {
        Task SendNotification(Guid OrderId);
    }
}