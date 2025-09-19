namespace OrdersApi.Repository
{
    public class FakeOrdersRepository : IOrdersRepository
    {
        static int counter = 0;
        public int InstanceNumber { get; set; }

        public FakeOrdersRepository()
        {
            InstanceNumber = ++counter;
        }

        public Task CreateOrder(Guid OrderId)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Order saved in database from instance #{InstanceNumber} of order's repository. OrderId ({OrderId})");
            });
        }
    }
}
