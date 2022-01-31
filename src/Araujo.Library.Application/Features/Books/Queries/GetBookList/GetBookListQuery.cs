using MediatR;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Books.Queries.GetBookList
{
    public class GetBookListQuery : IRequest<IReadOnlyList<BookListVm>>
    {
        public GetBookListQuery(int page, int size, bool avaliable)
        {
            Page = page;
            Size = size;
            Avaliable = avaliable;
        }
        public int Page { get; set; }
        public int Size { get; set; }
        public bool Avaliable { get; set; }
    }

}
