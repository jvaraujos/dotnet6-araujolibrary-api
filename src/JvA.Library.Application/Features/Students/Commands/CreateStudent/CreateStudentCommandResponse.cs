using JvA.Library.Application.Responses;

namespace JvA.Library.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandResponse : BaseResponse
    {
        public CreateStudentCommandResponse() : base()
        {

        }
        public CreateStudentCommandDto Student { get; set; }
    }
}
