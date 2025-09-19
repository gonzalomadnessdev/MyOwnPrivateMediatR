
namespace MyOwnPrivateMediatR
{
    public interface IDomainEventsBus
    {
        void Emit(IDomainEvent domainEvent);
        Task EmitSync(IDomainEvent domainEvent);
    }
}