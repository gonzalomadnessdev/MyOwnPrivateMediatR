namespace OrdersApi
{
    public class FakeService : IFakeService
    {
        static int counter = 0;

        public FakeService()
        {
            ++counter;
        }

        public Task SendNotification(Guid OrderId)
        {
            return Task.Run(() => {
                Thread.Sleep(2000); // Simulate some work
                Console.WriteLine($"Notification sent by #{counter} instance. OrderId ({OrderId})");
            });
        }
    }
}
