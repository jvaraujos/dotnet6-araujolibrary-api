using AutoMapper;
using Araujo.Library.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Araujo.Library.Application.Features.Books.Queries.BorrowBook
{
    public class BorrowBookQueryHandler :
        IRequestHandler<BorrowBookQuery, BorrowBookQueryResponse>


    {
        private readonly ILogger<BorrowBookQueryHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;


        public BorrowBookQueryHandler(ILogger<BorrowBookQueryHandler> logger,
            IBookRepository bookRepository,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<BorrowBookQueryResponse> Handle(BorrowBookQuery request, CancellationToken cancellationToken)
        {
            var createBookCommandResponse = new BorrowBookQueryResponse();

            var validator = new BorrowBookQueryValidator(_bookRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createBookCommandResponse.Success = false;
                createBookCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createBookCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createBookCommandResponse.Success)
            {
                var book = await _bookRepository.GetByIdAsync(request.BookId);
                var student = await _studentRepository.GetStudentByEmailAsync(request.StudentEmail);
                book.LentToStudentId = student.Id;
                await _bookRepository.UpdateAsync(book);
            }
            return createBookCommandResponse;
        }


    }
}
