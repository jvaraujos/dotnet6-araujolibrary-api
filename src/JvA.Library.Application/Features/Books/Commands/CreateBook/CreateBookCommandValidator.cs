using FluentValidation;
using JvA.Library.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public CreateBookCommandValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            RuleFor(p => p).MustAsync(IsBookUnique).WithMessage("Book exists.");

        }

        private async Task<bool> IsBookUnique(CreateBookCommand arg1, CancellationToken arg2)
        {
            return ! await _bookRepository.IsBookUnique(arg1.Title,arg1.Author);
        }
    }
}
