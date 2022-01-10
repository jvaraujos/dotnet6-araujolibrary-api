using FluentValidation;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Students.Queries.GetStudentList
{
    public class GetStudentListQueryValidator : AbstractValidator<GetStudentListQuery>
    {
        public GetStudentListQueryValidator()
        {
        }
    }
}
