using FluentValidation;
using JvA.Library.Application.Contracts.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Books.Queries.BorrowBook
{
    public class BorrowBookQueryValidator : AbstractValidator<BorrowBookQuery>
    {
        public IBookRepository _bookRepository { get; }

        public BorrowBookQueryValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            RuleFor(x => x).MustAsync(BookIsAvaliableToStudent).WithMessage("You can borrow books from your course.");
        }


        private async Task<bool> BookIsAvaliableToStudent(BorrowBookQuery arg1, CancellationToken arg2)
        {
            return await _bookRepository.BorrowBookAvaliableToStudentEmail(arg1.BookId, arg1.StudentEmail);
        }
    }
}
