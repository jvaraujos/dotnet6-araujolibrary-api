using JvA.Library.Application.Features.Books.Commands.CreateBook;
using JvA.Library.Application.Features.Books.Commands.DeleteBook;
using JvA.Library.Application.Features.Books.Commands.UpdateBook;
using JvA.Library.Application.Features.Books.Queries.BorrowBook;
using JvA.Library.Application.Features.Books.Queries.GetBookDetail;
using JvA.Library.Application.Features.Books.Queries.GetBookList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace JvA.Library.Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IMediator _mediator;
        public BooksController(ILogger<BooksController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<ActionResult<BookListVm>> GetAllBooks([FromQuery] int page = 1,
            [FromQuery] int size = 25, [FromQuery] bool avaliable = false)
        {
            var createBookCommandResponse = await _mediator.Send(new GetBookListQuery(page, size, avaliable));
            return Ok(createBookCommandResponse);
        }

        [HttpGet("{id:guid}", Name = "GetBookById")]
        public async Task<ActionResult<BookDetailVm>> GetBookById(Guid id)
        {
            return Ok(await _mediator.Send(new GetBookDetailQuery(id)));
        }

        [HttpPost(Name = "AddBook")]
        public async Task<ActionResult<CreateBookCommandResponse>> Create([FromBody] CreateBookCommand createBookCommand)
        {
            var createBookCommandResponse = await _mediator.Send(createBookCommand);
            return Ok(createBookCommandResponse);
        }

        [HttpPut(Name = "UpdateBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
        {
            await _mediator.Send(updateBookCommand);
            return NoContent();
        }

        [HttpDelete("{id:guid}", Name = "DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteBookCommand = new DeleteBookCommand(id);
            await _mediator.Send(deleteBookCommand);
            return NoContent();
        }

        [HttpPost]
        [Route("{id:guid}/Student/{studentEmail}")]
        public async Task<ActionResult> Post(
            [FromRoute] Guid id,
            [FromRoute] string studentEmail,
            [FromQuery] string action)
        {

            switch (action)
            {
                case "borrow":
                    var borrowBookQueryResponse = await _mediator.Send(new BorrowBookQuery(id, studentEmail));
                    return Ok(borrowBookQueryResponse);
                default:
                    return NotFound("Invalid action");
            }


        }
    }
}
