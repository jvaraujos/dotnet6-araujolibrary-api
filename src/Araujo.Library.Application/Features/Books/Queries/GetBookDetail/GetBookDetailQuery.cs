using MediatR;
using System;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQuery : IRequest<GetBookDetailQueryResponse>
    {

        public GetBookDetailQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }

}
