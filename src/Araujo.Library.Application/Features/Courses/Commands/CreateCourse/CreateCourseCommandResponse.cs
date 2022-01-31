using Araujo.Library.Application.Responses;

namespace Araujo.Library.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandResponse : BaseResponse
    {
        public CreateCourseCommandResponse() : base()
        {

        }
        public CreateCourseCommandDto Student { get; set; }
    }
}
