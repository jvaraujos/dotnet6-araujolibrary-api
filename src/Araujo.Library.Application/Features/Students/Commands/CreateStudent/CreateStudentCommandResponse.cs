using Araujo.Library.Application.Responses;

namespace Araujo.Library.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandResponse : BaseResponse
    {
        public CreateStudentCommandResponse() : base()
        {

        }
        public CreateStudentCommandDto Student { get; set; }
    }
}
