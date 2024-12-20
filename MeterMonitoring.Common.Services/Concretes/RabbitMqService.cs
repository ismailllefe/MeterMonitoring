﻿using MeterMonitoring.Library.Converters;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MeterMonitoring.Common.Services.Concretes
{
    public class RabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService()
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
        }

        public void Publish<T>(string routingKey, T data, string exchange = "")
        {
            var jsonData = JsonSerializer.Serialize(data);
            var base64Data = StringExtensions.ToBase64(jsonData);
            var body = Encoding.UTF8.GetBytes(base64Data);
            var props = _channel.CreateBasicProperties();
            props.DeliveryMode = 2;
            _channel.BasicPublish(exchange: exchange, routingKey: routingKey, props, body: body);
        }

        public void PublishMessage(string routingKey, string message)
        {
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "",
                                  routingKey: routingKey,
                                  basicProperties: null,
                                  body: body);

        }

        public void Dispose()
        {
            _channel.Close();
            _connection.Close();
        }
    }
}