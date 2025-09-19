
namespace OrdersApi.Repository
{
    public interface IOrdersRepository
    {
        int InstanceNumber { get; set; }

        Task CreateOrder(Guid OrderId);
    }
}