using MediatR;
using System;

namespace JvA.Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
