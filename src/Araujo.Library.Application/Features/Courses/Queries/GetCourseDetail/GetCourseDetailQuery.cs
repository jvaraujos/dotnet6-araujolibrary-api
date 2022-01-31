using MediatR;
using System;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Courses.Queries.GetCourseDetail
{
    public class GetCourseDetailQuery : IRequest<GetCourseDetailQueryResponse>
    {

        public GetCourseDetailQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

}
