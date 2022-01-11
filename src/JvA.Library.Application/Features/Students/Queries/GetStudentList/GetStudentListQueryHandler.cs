using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Students.Queries.GetStudentList
{
    public class GetStudentListQueryHandler :
        IRequestHandler<GetStudentListQuery, IReadOnlyList<StudentListVm>>
    {
        private readonly ILogger<GetStudentListQuery> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentListQueryHandler(ILogger<GetStudentListQuery> logger,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<StudentListVm>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var allStudents = (await _studentRepository.ListAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<StudentListVm>>(allStudents);
        }
    }
}
