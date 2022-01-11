using JvA.Library.Application.Responses;
using System.Collections.Generic;

namespace JvA.Library.Application.Features.Courses.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryResponse : BaseResponse
    {
        public GetCourseDetailQueryResponse() : base()
        {

        }
        public CourseDetailVm Course { get; set; }
    }
}
