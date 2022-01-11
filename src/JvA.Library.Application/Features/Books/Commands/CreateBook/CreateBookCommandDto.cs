using System;

namespace JvA.Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public Guid BookCategoryId { get; set; }
    }
}
