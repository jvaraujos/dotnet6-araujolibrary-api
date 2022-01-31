using MediatR;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Courses.Queries.GetCourseList
{
    public class GetCourseListQuery : IRequest<IReadOnlyList<CourseListVm>>
    {
        public GetCourseListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
