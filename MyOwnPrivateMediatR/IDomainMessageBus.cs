
namespace MyOwnPrivateMediatR
{
    public interface IDomainMessageBus
    {
        void Emit(object message);
        Task EmitSync(object message);
    }
}