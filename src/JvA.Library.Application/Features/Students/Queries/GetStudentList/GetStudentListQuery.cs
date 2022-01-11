using MediatR;
using System.Collections.Generic;

namespace JvA.Library.Application.Features.Students.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<IReadOnlyList<StudentListVm>>
    {
        public GetStudentListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
