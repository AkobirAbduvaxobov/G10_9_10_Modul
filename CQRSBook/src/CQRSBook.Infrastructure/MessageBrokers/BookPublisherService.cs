using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace CQRSBook.Infrastructure.MessageBrokers;

public class BookPublisherService : IBookGRPCService
{
    private readonly ConnectionFactory _factory;

    public BookPublisherService()
    {
        _factory = new ConnectionFactory() { HostName = "host.docker.internal" };
    }

    public async Task<long> AddAsync(Book book)
    {
        using IConnection connection = await _factory.CreateConnectionAsync();
        using IChannel channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: "book-queue",
                             durable: true,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var json = JsonSerializer.Serialize(book);
        var body = Encoding.UTF8.GetBytes(json);

        var basicProperties = new BasicProperties();   
        await channel.BasicPublishAsync(exchange: "",
                             routingKey: "book-queue",
                             basicProperties: basicProperties,
                             mandatory: false,
                             body: body);

        return 1;
    }

    public Task<List<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
