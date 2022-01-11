using JvA.Library.Application.Responses;
using System.Collections.Generic;

namespace JvA.Library.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQueryResponse : BaseResponse
    {
        public GetBookDetailQueryResponse() : base()
        {

        }
        public BookDetailVm Book { get; set; }
    }
}
