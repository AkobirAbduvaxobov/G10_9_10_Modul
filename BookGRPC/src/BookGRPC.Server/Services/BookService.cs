using BookContracts;
using BookGRPC.Server.Contracts;
using Grpc.Core;


namespace BookGRPC.Server.Services;

public class BookService : BookContracts.BookService.BookServiceBase
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public override async Task<CreateResponse> Add(CreateRequest request, ServerCallContext context)
    {
        var res = await _repository.AddAsync(request);
        return res;
    }

    public override async Task<GetAllResponse> GetAll(GetAllRequest request, ServerCallContext context)
    {
        var res = await _repository.GetAllAsync(request);
        return res;
    }
}
