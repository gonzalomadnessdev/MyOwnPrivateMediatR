namespace OrdersApi.Services
{
    public class FakeNotificationsService : INotificationsService
    {
        static int counter = 0;
        public int InstanceNumber { get; set; }

        public FakeNotificationsService()
        {
            InstanceNumber = ++counter;
        }

        public Task SendNotification(Guid OrderId)
        {
            return Task.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine($"Notification sent from instance #{InstanceNumber} of notification's service. OrderId ({OrderId})");
            });
        }
    }
}
