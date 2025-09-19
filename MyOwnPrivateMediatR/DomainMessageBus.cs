using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyOwnPrivateMediatR
{
    public class DomainMessageBus : IDomainMessageBus
    {
        public static DomainMessageBusOptions Options { get; } = new DomainMessageBusOptions();

        private Dictionary<string, IDomainMessageHandler> _handlers = new Dictionary<string, IDomainMessageHandler>();
        public DomainMessageBus(
            IServiceProvider serviceProvider
        )
        {
            var assembly = Assembly.GetEntryAssembly() ?? throw new Exception("Cannot get entry assembly");

            var types = assembly.GetTypes()
                .Where(t => typeof(IDomainMessageHandler).IsAssignableFrom(t)
                            && t.IsClass
                            && !t.IsAbstract)
                .ToList();

            var domainMessageHandlers = types.Select(t => serviceProvider.GetRequiredService(t)).Where(o => o != null).ToList();

            foreach (var _handler in domainMessageHandlers)
            {
                IDomainMessageHandler handler = (_handler as IDomainMessageHandler) ?? throw new Exception($"Cannot cast to {nameof(IDomainMessageHandler)}");
                string messageName = handler.GetType().BaseType!.GetGenericArguments().First().Name;
                _handlers.Add(messageName, handler);
            }
        }

        public void Emit(IDomainMessage message)
        {
            var typeName = message.GetType().Name;

            if (_handlers.TryGetValue(typeName, out var handler))
            {
                Task.Run(() => handler.Handle(message));
            }
            else
            {
                throw new Exception($"No handler found for message {typeName}");
            }
        }

        public async Task EmitSync(IDomainMessage message)
        {
            var typeName = message.GetType().Name;
            if (_handlers.TryGetValue(typeName, out var handler))
            {
                await handler.Handle(message);
            }
            else
            {
                throw new Exception($"No handler found for message {typeName}");
            }
        }
    }

    public class DomainMessageBusOptions
    {
        public List<Type> HandlerTypes { get; } = [];

        public DomainMessageBusOptions AddHandler<T>() where T : IDomainMessageHandler
        {
            HandlerTypes.Add(typeof(T));
            return this;
        }
    }
}