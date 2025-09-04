using BookConsumer.Api.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace BookConsumer.Api.Services;

public class BookConsumerService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public BookConsumerService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = await factory.CreateConnectionAsync();
        var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "book-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new AsyncEventingBasicConsumer(channel); 

        consumer.ReceivedAsync += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
            var book = JsonSerializer.Deserialize<Book>(message);

            if (book != null)
            {
                Console.WriteLine($"Book saved: {book.Title} by {book.Author}");
            }
        };

        await channel.BasicConsumeAsync(queue: "book-queue",
                             autoAck: true,
                             consumer: consumer);
    }
}
