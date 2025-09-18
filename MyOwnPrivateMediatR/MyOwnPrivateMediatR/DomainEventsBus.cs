using System.Reflection;

namespace MyOwnPrivateMediatR.MyOwnPrivateMediatR
{
    public class DomainEventsBus
    {
        private Dictionary<string, IDomainEventHandler> _handlers = new Dictionary<string, IDomainEventHandler>();
        public DomainEventsBus(
            IServiceProvider serviceProvider
        )
        {
            var assembly = Assembly.GetExecutingAssembly();

            var types = assembly.GetTypes()
                .Where(t => typeof(IDomainEventHandler).IsAssignableFrom(t)
                            && t.IsClass
                            && !t.IsAbstract)
                .ToList();

            //var domainEventsHandlers = types.Select(t => Activator.CreateInstance(t)).Where(o => o != null).ToList();
            var domainEventsHandlers = types.Select(t => serviceProvider.GetRequiredService(t)).Where(o => o != null).ToList(); //IServiceProvider serviceProvider

            foreach (var _handler  in domainEventsHandlers)
            {
                IDomainEventHandler handler = (_handler as IDomainEventHandler) ?? throw new Exception($"Cannot cast to {nameof(IDomainEventHandler)}");
                string eventName = handler.GetType().Name.Replace("Handler", "");

                _handlers.Add(eventName, handler);
            }

        }

        public void Emit(IDomainEvent domainEvent){
            var typeName = domainEvent.GetType().Name;

            if (_handlers.TryGetValue(typeName, out var handler)) {
                Task.Run(() => handler.Handle(domainEvent));
            }
        }
    }
}