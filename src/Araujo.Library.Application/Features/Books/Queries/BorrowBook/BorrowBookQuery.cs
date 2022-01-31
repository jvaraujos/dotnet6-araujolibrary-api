using MediatR;
using System;

namespace Araujo.Library.Application.Features.Books.Queries.BorrowBook
{
    public class BorrowBookQuery : IRequest<BorrowBookQueryResponse>
    {
        public BorrowBookQuery(Guid bookId, string studentEmail)
        {
            BookId = bookId;
            StudentEmail = studentEmail;
        }

        public Guid BookId { get; set; }
        public string StudentEmail { get; set; }
    }

}
