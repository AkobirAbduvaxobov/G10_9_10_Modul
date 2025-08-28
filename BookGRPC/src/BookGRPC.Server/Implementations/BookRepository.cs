using BookContracts;
using BookGRPC.Server.Contracts;
using BookGRPC.Server.Persistence;
using Microsoft.EntityFrameworkCore;


namespace BookGRPC.Server.Implementations;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponse> AddAsync(CreateRequest request)
    {
        Entities.Book bookEntity = new Entities.Book()
        {
            Title = request.Book.Title,
            Author = request.Book.Author,
            ISBN = request.Book.Isbn,
            Publisher = request.Book.Publisher,
            //PublishDate = request.Book.PublishDate,
            Pages = request.Book.Pages,
            Genre = request.Book.Genre,
            Language = request.Book.Language,
            Price = (decimal)request.Book.Price
        };

        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();
        return new CreateResponse() { BookId = bookEntity.BookId };
    }

    public async Task<GetAllResponse> GetAllAsync(GetAllRequest request)
    {
        List<Entities.Book> books = await _context.Books.ToListAsync();
        GetAllResponse response = new GetAllResponse();
        foreach (var book in books)
        {
            response.Items.Add(new Book()
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Isbn = book.ISBN,
                Publisher = book.Publisher,
                Pages = book.Pages,
                Genre = book.Genre,
                Language = book.Language,
                Price = (double)book.Price
            });
        }

        return response;
    }    
}
