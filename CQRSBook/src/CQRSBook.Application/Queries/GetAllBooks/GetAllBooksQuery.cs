using CQRSBook.Application.Dtos;
using CQRSBook.Application.Interfaces;
using MediatR;

namespace CQRSBook.Application.Queries.GetAllBooks;

public class GetAllBooksQuery : IRequestHandler<GetAllBooksHandler, ICollection<BookGetDto>>
{
    private readonly IBookReadRepository _readRepo;
    private readonly IBookGRPCService _bookGRPCService;

    public GetAllBooksQuery(IBookReadRepository readRepo, IBookGRPCService bookGRPCService)
    {
        _readRepo = readRepo;
        _bookGRPCService = bookGRPCService;
    }

    public async Task<ICollection<BookGetDto>> Handle(GetAllBooksHandler request, CancellationToken cancellationToken)
    {
        
        //var books = await _readRepo.GetAllAsync();
        var books = await _bookGRPCService.GetAllAsync();
        var bookDtos = books.Select(b => new BookGetDto
        {
            BookId = b.BookId,
            Title = b.Title,
            Author = b.Author,
            ISBN = b.ISBN,
            Publisher = b.Publisher,
            PublishDate = b.PublishDate,
            Pages = b.Pages,
            Genre = b.Genre,
            Language = b.Language,
            Price = b.Price
        }).ToList();

        return bookDtos;
    }
}
