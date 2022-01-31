using Araujo.Library.Application.Features.Courses.Commands.CreateCourse;
using Araujo.Library.Application.Features.Courses.Commands.DeleteCourse;
using Araujo.Library.Application.Features.Courses.Commands.UpdateCourse;
using Araujo.Library.Application.Features.Courses.Queries.GetCourseDetail;
using Araujo.Library.Application.Features.Courses.Queries.GetCourseList;
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
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly IMediator _mediator;
        public CoursesController(ILogger<CoursesController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllCourses")]
        public async Task<ActionResult<CourseListVm>> GetAllCourses([FromQuery] int page = 1, [FromQuery] int size = 25)
        {
            var createCourseListQueryResponse = await _mediator.Send(new GetCourseListQuery(page, size));
            return Ok(createCourseListQueryResponse);
        }

        [HttpGet("{id:guid}", Name = "GetCourseById")]
        public async Task<ActionResult<CourseDetailVm>> GetCourseById(Guid id)
        {
            return Ok(await _mediator.Send(new GetCourseDetailQuery(id)));
        }

        [HttpPost(Name = "AddCourse")]
        public async Task<ActionResult<CreateCourseCommandResponse>> Create([FromBody] CreateCourseCommand createCourseCommand)
        {
            var createCourseCommandResponse = await _mediator.Send(createCourseCommand);
            return Ok(createCourseCommandResponse);
        }

        [HttpPut(Name = "UpdateCourse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCourseCommand updateCourseCommand)
        {
            await _mediator.Send(updateCourseCommand);
            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteCourse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCourseCommand = new DeleteCourseCommand(id);
            await _mediator.Send(deleteCourseCommand);
            return NoContent();
        }
    }
}
