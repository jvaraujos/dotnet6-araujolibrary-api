using JvA.Library.Application.Responses;

namespace JvA.Library.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandResponse : BaseResponse
    {
        public CreateCourseCommandResponse() : base()
        {

        }
        public CreateCourseCommandDto Student { get; set; }
    }
}
