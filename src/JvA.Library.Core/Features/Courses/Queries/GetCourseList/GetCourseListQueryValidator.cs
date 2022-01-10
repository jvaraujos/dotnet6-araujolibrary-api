using FluentValidation;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace JvA.Library.Application.Features.Courses.Queries.GetCourseList
{
    public class GetCourseListQueryValidator : AbstractValidator<GetCourseListQuery>
    {
        public GetCourseListQueryValidator()
        {
        }
    }
}
