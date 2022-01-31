using Araujo.Library.Application.Responses;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Books.Queries.GetBookDetail
{
    public class GetBookDetailQueryResponse : BaseResponse
    {
        public GetBookDetailQueryResponse() : base()
        {

        }
        public BookDetailVm Book { get; set; }
    }
}
