using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyOwnPrivateMediatR
{
    public class DomainEventsBus
    {
        const string HANDLER_SUFFIX = "Handler";

        private Dictionary<string, IDomainEventHandler> _handlers = new Dictionary<string, IDomainEventHandler>();
        public DomainEventsBus(
            IServiceProvider serviceProvider
        )
        {
            var assembly = Assembly.GetEntryAssembly() ?? throw new Exception("Cannot get entry assembly");

            var types = assembly.GetTypes()
                .Where(t => typeof(IDomainEventHandler).IsAssignableFrom(t)
                            && t.IsClass
                            && !t.IsAbstract)
                .ToList();

            var domainEventsHandlers = types.Select(t => serviceProvider.GetRequiredService(t)).Where(o => o != null).ToList();

            foreach (var _handler  in domainEventsHandlers)
            {
                IDomainEventHandler handler = (_handler as IDomainEventHandler) ?? throw new Exception($"Cannot cast to {nameof(IDomainEventHandler)}");
                string eventName = handler.GetType().Name.Replace(HANDLER_SUFFIX, String.Empty);

                _handlers.Add(eventName, handler);
            }

        }

        public void Emit(IDomainEvent domainEvent){
            var typeName = domainEvent.GetType().Name;

            if (_handlers.TryGetValue(typeName, out var handler))
            {
                Task.Run(() => handler.Handle(domainEvent));
            }
            else
            {
                throw new Exception($"No handler found for event {typeName}");
            }
        }

        public async Task EmitSync(IDomainEvent domainEvent){
            var typeName = domainEvent.GetType().Name;
            if (_handlers.TryGetValue(typeName, out var handler)) {
                await handler.Handle(domainEvent);
            }
            else
            {
                throw new Exception($"No handler found for event {typeName}");
            }
        }
    }
}