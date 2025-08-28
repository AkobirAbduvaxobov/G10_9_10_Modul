using BookContracts;
using BookGRPC.Server.Entities;

namespace BookGRPC.Server.Contracts;

public interface IBookRepository
{
    Task<CreateResponse> AddAsync(CreateRequest request);
    Task<GetAllResponse> GetAllAsync(GetAllRequest request);
}
