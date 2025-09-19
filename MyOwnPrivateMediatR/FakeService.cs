namespace MyOwnPrivateMediatR
{
    public class FakeService : IFakeService
    {
        static int counter = 0;

        public FakeService()
        {
            ++counter;
        }

        public void SendNotification() => Console.WriteLine($"Notification sent by #{counter} instance");
    }
}
