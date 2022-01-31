using Araujo.Library.Application.Responses;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Courses.Queries.GetCourseDetail
{
    public class GetCourseDetailQueryResponse : BaseResponse
    {
        public GetCourseDetailQueryResponse() : base()
        {

        }
        public CourseDetailVm Course { get; set; }
    }
}
