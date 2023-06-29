using System.Reflection;
using System.Text;
using Authentication.Application.ViewModels;
using Authentication.Services.WorkerService;
using Authentication.Services.WorkerService.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using IHost host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "NewAssociateQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    var associateIdentification = System.Text.Json.JsonSerializer.Deserialize<AssociateIdentificationViewModel>(message);

    services.GetRequiredService<App>().Run(associateIdentification);
};

channel.BasicConsume(queue: "NewAssociateQueue",
                     autoAck: true,
                     consumer: consumer);

Console.ReadLine();


IHostBuilder CreateHostBuilder(string[] strings)
{
    var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);

    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddDatabaseSetup(configurationBuilder.Build());
            services.AddAutoMapperSetup();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddDependencyInjectionSetup();
        });
}