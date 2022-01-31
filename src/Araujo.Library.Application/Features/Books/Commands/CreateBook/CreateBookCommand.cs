using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Araujo.Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<CreateBookCommandResponse>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public Guid BookCategoryId { get; set; }
    }
}
