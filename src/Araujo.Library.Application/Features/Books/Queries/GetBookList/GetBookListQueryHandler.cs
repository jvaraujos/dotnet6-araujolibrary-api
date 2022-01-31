using AutoMapper;
using Araujo.Library.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Araujo.Library.Application.Features.Books.Queries.GetBookList
{
    public class GetBookListQueryHandler :
        IRequestHandler<GetBookListQuery, IReadOnlyList<BookListVm>>
    {
        private readonly ILogger<GetBookListQueryHandler> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public GetBookListQueryHandler(ILogger<GetBookListQueryHandler> logger,
            IBookRepository bookRepository,
            IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<BookListVm>> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {

            var allBooks = (await _bookRepository.GetAllBooksPagedResponseByAvaliableAsync(request.Page, request.Size, request.Avaliable))
                .OrderBy(x => x.Title);
            return _mapper.Map<List<BookListVm>>(allBooks);
        }


    }
}
