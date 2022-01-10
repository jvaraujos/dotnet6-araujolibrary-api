using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {

            var studentToUpdate = await _studentRepository.GetByIdAsync(request.Id);

            if (studentToUpdate == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            var validator = new UpdateStudentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, studentToUpdate, typeof(UpdateStudentCommand), typeof(Student));

            await _studentRepository.UpdateAsync(studentToUpdate);

            return Unit.Value;
        }
    }
}
