using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Courses.Queries.GetCourseList
{
    public class GetCourseListQueryHandler :
        IRequestHandler<GetCourseListQuery, IReadOnlyList<CourseListVm>>
    {
        private readonly ILogger<GetCourseListQuery> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetCourseListQueryHandler(ILogger<GetCourseListQuery> logger,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<CourseListVm>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var allCourses = (await _courseRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CourseListVm>>(allCourses);
        }
    }
}
