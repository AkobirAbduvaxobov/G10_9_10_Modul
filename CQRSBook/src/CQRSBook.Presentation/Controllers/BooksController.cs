using CQRSBook.Application.Commands.CreateBook;
using CQRSBook.Application.Dtos;
using CQRSBook.Application.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRSBook.Presentation.Controllers;

[Route("v1/api")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IMediator _mediator;
    public BooksController(IMediator mediator) => _mediator = mediator;

    [HttpPost("books")]
    public async Task<ActionResult<long>> Create(CreateBookCommand command)
    {
        var result = await _mediator.Send(command);
        return result;
    }

    [HttpGet("books")]
    public async Task<ActionResult<ICollection<BookGetDto>>> GetAll()
    {
        var command = new GetAllBooksHandler();
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
