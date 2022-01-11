using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {

            var courseToUpdate = await _courseRepository.GetByIdAsync(request.Id);

            if (courseToUpdate == null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            var validator = new UpdateCourseCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, courseToUpdate, typeof(UpdateCourseCommand), typeof(Course));

            await _courseRepository.UpdateAsync(courseToUpdate);

            return Unit.Value;
        }
    }
}
