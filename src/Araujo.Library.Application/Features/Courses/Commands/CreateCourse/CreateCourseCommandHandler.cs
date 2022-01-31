using AutoMapper;
using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Araujo.Library.Application.Features.Courses.Commands.CreateCourse
{
    public class BorrowBookQueryHandler :
        IRequestHandler<CreateCourseCommand, CreateCourseCommandResponse>
    {
        private readonly ILogger<CreateCourseCommand> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public BorrowBookQueryHandler(
            ILogger<CreateCourseCommand> logger,
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var createStudentCommandResponse = new CreateCourseCommandResponse();

            var validator = new CreateCourseCommandValidator();
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
                var course = _mapper.Map<Course>(request);
                course = await _courseRepository.AddAsync(course);
                createStudentCommandResponse.Student = _mapper.Map<CreateCourseCommandDto>(course);
            }
            return createStudentCommandResponse;
        }


    }
}
