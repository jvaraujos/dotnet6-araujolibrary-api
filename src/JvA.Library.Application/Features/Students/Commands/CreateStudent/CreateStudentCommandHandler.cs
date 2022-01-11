using AutoMapper;
using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Students.Commands.CreateStudent
{
    public class BorrowBookQueryHandler :
        IRequestHandler<CreateStudentCommand, CreateStudentCommandResponse>
    {
        private readonly ILogger<CreateStudentCommand> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public BorrowBookQueryHandler(
            ILogger<CreateStudentCommand> logger,
            IStudentRepository studentRepository,
            IMapper mapper)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var createStudentCommandResponse = new CreateStudentCommandResponse();

            var validator = new CreateStudentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createStudentCommandResponse.Success = false;
                createStudentCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createStudentCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createStudentCommandResponse.Success)
            {
                var book = _mapper.Map<Student>(request);
                book = await _studentRepository.AddAsync(book);
                createStudentCommandResponse.Student = _mapper.Map<CreateStudentCommandDto>(book);
            }
            return createStudentCommandResponse;
        }


    }
}
