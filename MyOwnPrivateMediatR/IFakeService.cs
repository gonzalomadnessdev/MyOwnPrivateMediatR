namespace MyOwnPrivateMediatR
{
    public interface IFakeService
    {
        Task SendNotification(Guid OrderId);
    }
}