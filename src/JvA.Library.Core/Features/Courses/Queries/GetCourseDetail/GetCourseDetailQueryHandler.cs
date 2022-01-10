using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Courses.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryHandler :
        IRequestHandler<GetCourseDetailQuery, GetCourseDetailQueryResponse>
    {
        private readonly ILogger<GetCourseDetailQuery> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetCourseDetailQueryHandler(ILogger<GetCourseDetailQuery> logger,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<GetCourseDetailQueryResponse> Handle(GetCourseDetailQuery request, CancellationToken cancellationToken)
        {
            var getCourseDetailQueryResponse = new GetCourseDetailQueryResponse();
            var student = await _courseRepository.GetByIdAsync(request.Id);

            if (student == null)
            {
                throw new NotFoundException(nameof(Course), request.Id);
            }

            getCourseDetailQueryResponse.Course = _mapper.Map<CourseDetailVm>(student);

            return getCourseDetailQueryResponse;
        }


    }
}
