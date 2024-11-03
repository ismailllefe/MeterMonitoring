using DatabaseLibrary.Data;
using MeterMonitoring.Rabbit.Consumer.Helpers;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly ReportHelper reportHelper;

        public RequestConsumerManager( ReportHelper reportHelper)
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

            this.reportHelper = reportHelper;
        }
        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                reportHelper.CreateReportContent(message);

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