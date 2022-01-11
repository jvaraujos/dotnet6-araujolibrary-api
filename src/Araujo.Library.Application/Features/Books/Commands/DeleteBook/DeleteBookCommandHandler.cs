using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var bookToDelete = await _bookRepository.GetByIdAsync(request.Id);

            if (bookToDelete == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            await _bookRepository.DeleteAsync(bookToDelete);

            return Unit.Value;
        }
    }
}
