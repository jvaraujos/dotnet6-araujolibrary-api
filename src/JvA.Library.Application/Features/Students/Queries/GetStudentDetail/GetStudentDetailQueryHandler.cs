using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Application.Exceptions;
using JvA.Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryHandler :
        IRequestHandler<GetStudentDetailQuery, GetStudentDetailQueryResponse>
    {
        private readonly ILogger<GetStudentDetailQuery> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentDetailQueryHandler(ILogger<GetStudentDetailQuery> logger,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<GetStudentDetailQueryResponse> Handle(GetStudentDetailQuery request, CancellationToken cancellationToken)
        {
            var getStudentDetailQueryResponse = new GetStudentDetailQueryResponse();
            var student = await _studentRepository.GetByIdAsync(request.Id);

            if (student == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            getStudentDetailQueryResponse.Book = _mapper.Map<StudentDetailVm>(student);

            return getStudentDetailQueryResponse;
        }


    }
}
