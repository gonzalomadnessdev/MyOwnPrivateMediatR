namespace MyOwnPrivateMediatR
{
    public interface IDomainMessageHandler
    {
        public Task Handle(IDomainMessage message);
    }
}