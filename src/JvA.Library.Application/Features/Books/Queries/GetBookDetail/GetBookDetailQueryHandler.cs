using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQueryHandler :
        IRequestHandler<GetBookDetailQuery, GetBookDetailQueryResponse>
    {
        private readonly ILogger<GetBookDetailQueryHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookDetailQueryHandler(ILogger<GetBookDetailQueryHandler> logger,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<GetBookDetailQueryResponse> Handle(GetBookDetailQuery request, CancellationToken cancellationToken)
        {
            var getBookDetailQueryResponse = new GetBookDetailQueryResponse();
            var book = await _bookRepository.GetByIdAsync(request.Id);

            if (book == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            getBookDetailQueryResponse.Book = _mapper.Map<BookDetailVm>(book);

            return getBookDetailQueryResponse;
        }


    }
}
