using JvA.Library.Application.Responses;

namespace JvA.Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandResponse : BaseResponse
    {
        public CreateBookCommandResponse() : base()
        {

        }
        public CreateBookCommandDto Book { get; set; }
    }
}
