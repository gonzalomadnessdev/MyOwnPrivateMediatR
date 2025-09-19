namespace MyOwnPrivateMediatR
{
    public interface IDomainMessageHandler
    {
        public Task Handle(object message);
    }
}