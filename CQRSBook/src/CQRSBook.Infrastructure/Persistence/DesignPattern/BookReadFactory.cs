using CQRSBook.Application.Interfaces;
using CQRSBook.Infrastructure.Persistence.Repositories;

namespace CQRSBook.Infrastructure.Persistence.DesignPattern;

public static class BookReadFactory
{
    public static IBookReadRepository CreateStrategy(string type)
    {
        return type.ToLower() switch
        {
            //"mongoDB" => new MongoBookReadRepository(),
            //"sqlServer" => new BookReadRepository(),
            _ => throw new ArgumentException("Unsupported DB type")
        };
    }
}
