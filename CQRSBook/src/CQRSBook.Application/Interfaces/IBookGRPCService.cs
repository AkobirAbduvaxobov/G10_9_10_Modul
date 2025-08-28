using CQRSBook.Domain.Entities;

namespace CQRSBook.Application.Interfaces;

public interface IBookGRPCService
{
    Task<long> AddAsync(Book book);
    Task<List<Book>> GetAllAsync();
}
