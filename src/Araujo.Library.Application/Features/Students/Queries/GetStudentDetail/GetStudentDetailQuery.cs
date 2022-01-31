using MediatR;
using System;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQuery : IRequest<GetStudentDetailQueryResponse>
    {

        public GetStudentDetailQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

}
