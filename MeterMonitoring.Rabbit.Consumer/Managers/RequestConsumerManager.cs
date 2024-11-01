using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics.Metrics;
using System.Text;
using System.Text.Json;


namespace MeterMonitoring.Rabbit.Consumer.Managers
{
    public class RequestConsumerManager : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly string _queueName = "Request";
        public RequestConsumerManager()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "127.0.0.1",
                Port = 10001,
                UserName = "guest",
                Password = "guest"
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(queue: "Request",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var meter = JsonSerializer.Deserialize<Meter>(message);
            };

        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
            };

            _channel.BasicConsume(queue: _queueName,
                                  autoAck: true,
                                  consumer: consumer);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

    }
}