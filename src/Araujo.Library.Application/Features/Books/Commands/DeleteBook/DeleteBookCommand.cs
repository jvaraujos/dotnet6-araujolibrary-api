using MediatR;
using System;

namespace Araujo.Library.Application.Features.Books.Commands.DeleteBook
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
