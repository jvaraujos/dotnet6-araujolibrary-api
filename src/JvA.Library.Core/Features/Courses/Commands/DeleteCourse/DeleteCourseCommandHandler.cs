using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Courses.Commands.DeleteCourse
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHandler(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var courseToDelete = await _courseRepository.GetByIdAsync(request.Id);

            if (courseToDelete == null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            await _courseRepository.DeleteAsync(courseToDelete);

            return Unit.Value;
        }
    }
}
