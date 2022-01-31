using AutoMapper;
using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Application.Exceptions;
using Araujo.Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Araujo.Library.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(request.Id);

            if (studentToDelete == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            await _studentRepository.DeleteAsync(studentToDelete);

            return Unit.Value;
        }
    }
}
