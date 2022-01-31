using Araujo.Library.Application.Responses;

namespace Araujo.Library.Application.Features.Books.Commands.CreateBook
{
    public class CreateBookCommandResponse : BaseResponse
    {
        public CreateBookCommandResponse() : base()
        {

        }
        public CreateBookCommandDto Book { get; set; }
    }
}
