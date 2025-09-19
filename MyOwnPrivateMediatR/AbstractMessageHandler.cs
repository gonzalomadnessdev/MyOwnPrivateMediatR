using Microsoft.Extensions.DependencyInjection;

namespace MyOwnPrivateMediatR
{
    abstract public class AbstractMessageHandler<TDomainMessage> : IDomainMessageHandler where TDomainMessage : class, IDomainMessage
    {
        protected readonly IServiceScopeFactory _serviceScopeFactory;

        protected AbstractMessageHandler(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        abstract public Task Handle(TDomainMessage message);

        public async Task Handle(IDomainMessage message)
        {
            var _message = message as TDomainMessage ?? throw new InvalidCastException();
            await Handle(_message);
        }
    }
}
