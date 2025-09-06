//using BookContracts; 
//using CQRSBook.Application.Interfaces;
//using Google.Protobuf.WellKnownTypes;
//using Book = CQRSBook.Domain.Entities.Book;

//namespace CQRSBook.Infrastructure.GRPCSide;

//public class BookGRPCService : IBookGRPCService
//{
//    private readonly BookService.BookServiceClient _client;

//    public BookGRPCService(BookService.BookServiceClient client)
//    {
//        _client = client;
//    }

//    public async Task<long> AddAsync(Book book)
//    {
//        var request = new CreateRequest
//        {
//            Book = new BookContracts.Book
//            {
//                BookId = book.BookId,
//                Title = book.Title,
//                Author = book.Author,
//                Isbn = book.ISBN,
//                Publisher = book.Publisher,
//                Pages = book.Pages,
//                Genre = book.Genre,
//                Language = book.Language,
//                Price = (double)book.Price
//            }
//        };

//        var response = await _client.AddAsync(request);
//        return response.BookId;
//    }

//    public async Task<List<Book>> GetAllAsync()
//    {
//        var response = await _client.GetAllAsync(new GetAllRequest());

//        return response.Items.Select(b => new Book
//        {
//            BookId = b.BookId,
//            Title = b.Title,
//            Author = b.Author,
//            ISBN = b.Isbn,
//            Publisher = b.Publisher,
//            Pages = b.Pages,
//            Genre = b.Genre,
//            Language = b.Language,
//            Price = (decimal)b.Price
//        }).ToList();
//    }
//}
