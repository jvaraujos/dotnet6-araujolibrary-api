using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler :
        IRequestHandler<CreateBookCommand, CreateBookCommandResponse>


    {
        private readonly ILogger<CreateBookCommandHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public CreateBookCommandHandler(
            ILogger<CreateBookCommandHandler> logger,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var createBookCommandResponse = new CreateBookCommandResponse();

            var validator = new CreateBookCommandValidator(_bookRepository);
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
                var book = _mapper.Map<Book>(request);
                book = await _bookRepository.AddAsync(book);
                createBookCommandResponse.Book = _mapper.Map<CreateBookCommandDto>(book);
            }
            return createBookCommandResponse;
        }


    }
}
