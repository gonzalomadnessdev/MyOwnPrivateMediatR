namespace OrdersApi
{
    public class FakeService : IFakeService
    {
        static int counter = 0;
        public int InstanceNumber { get; set; }

        public FakeService()
        {
            InstanceNumber = ++counter;
        }

        public Task SendNotification(Guid OrderId)
        {
            return Task.Run(() => {
                Thread.Sleep(2000);
                Console.WriteLine($"Notification sent by #{InstanceNumber} instance of service. OrderId ({OrderId})");
            });
        }
    }
}
