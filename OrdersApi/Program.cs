using MyOwnPrivateMediatR;
using OrdersApi.Commands.Handlers;
using OrdersApi.Events.Handlers;
using OrdersApi.Repository;
using OrdersApi.Services;

namespace OrdersApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IOrdersRepository, FakeOrdersRepository>();
            builder.Services.AddScoped<INotificationsService, FakeNotificationsService>();
            builder.Services.AddDomainMessageBus(
                (options) => options.AddHandler<OrderCreatedEventHandler>()
                                    .AddHandler<AnotherOrderCreatedEventHandler>()
                                    .AddHandler<CreateOrderCommandHandler>()
            );
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
