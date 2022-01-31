using Araujo.Library.Application.Features.Students.Commands.CreateStudent;
using Araujo.Library.Application.Features.Students.Commands.DeleteStudent;
using Araujo.Library.Application.Features.Students.Commands.UpdateStudent;
using Araujo.Library.Application.Features.Students.Queries.GetStudentDetail;
using Araujo.Library.Application.Features.Students.Queries.GetStudentList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Araujo.Library.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IMediator _mediator;
        public StudentsController(ILogger<StudentsController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public async Task<ActionResult<StudentListVm>> GetAllStudents([FromQuery] int page = 1,
            [FromQuery] int size = 25)
        {
            var allStudents = await _mediator.Send(new GetStudentListQuery(page, size));
            return Ok(allStudents);
        }

        [HttpGet("{id:guid}", Name = "GetStudentById")]
        public async Task<ActionResult<StudentDetailVm>> GetStudentById(Guid id)
        {
            var getStudentDetailQuery = new GetStudentDetailQuery(id);
            return Ok(await _mediator.Send(getStudentDetailQuery));
        }

        [HttpPost(Name = "AddStudent")]
        public async Task<ActionResult<CreateStudentCommandResponse>> Create([FromBody] CreateStudentCommand createStudentCommand)
        {
            var createStudentCommandResponse = await _mediator.Send(createStudentCommand);
            return Ok(createStudentCommandResponse);
        }

        [HttpPut(Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
        {
            await _mediator.Send(updateStudentCommand);
            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteStudentCommand = new DeleteStudentCommand(id);
            await _mediator.Send(deleteStudentCommand);
            return NoContent();
        }


    }
}
