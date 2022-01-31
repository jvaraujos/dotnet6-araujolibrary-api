using FluentValidation;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Araujo.Library.Application.Features.Books.Queries.GetBookList
{
    public class GetBookListQueryValidator : AbstractValidator<GetBookListQuery>
    {
        public GetBookListQueryValidator()
        {
        }
    }
}
