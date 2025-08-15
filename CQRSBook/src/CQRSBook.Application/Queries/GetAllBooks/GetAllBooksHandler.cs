using CQRSBook.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSBook.Application.Queries.GetAllBooks;

public record GetAllBooksHandler() : IRequest<ICollection<BookGetDto>>;
