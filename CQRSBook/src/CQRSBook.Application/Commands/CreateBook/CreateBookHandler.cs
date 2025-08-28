using CQRSBook.Application.Interfaces;
using CQRSBook.Domain.Entities;
using MediatR;

namespace CQRSBook.Application.Commands.CreateBook;

public class CreateBookHandler : IRequestHandler<CreateBookCommand, long>
{
    private readonly IBookWriteRepository _writeRepo;
    private readonly IBookGRPCService _bookGRPCService;
    public CreateBookHandler(IBookWriteRepository repo, IBookGRPCService bookGRPCService)
    {
        _writeRepo = repo;
        _bookGRPCService = bookGRPCService;
    }

    public async Task<long> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var entity = new Book
        {
            Title = request.Title,
            Author = request.Author,
            ISBN = request.ISBN,
            Publisher = request.Publisher,
            PublishDate = request.PublishDate,
            Pages = request.Pages,
            Genre = request.Genre,
            Language = request.Language,
            Price = request.Price
        };

        //var bookId = await _writeRepo.AddAsync(entity);
        var bookId = await _bookGRPCService.AddAsync(entity);

        return bookId;
    }
}
