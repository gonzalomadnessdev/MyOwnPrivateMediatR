
namespace MyOwnPrivateMediatR
{
    public interface IDomainMessageBus
    {
        void Emit(IDomainMessage message);
        Task EmitSync(IDomainMessage message);
    }
}