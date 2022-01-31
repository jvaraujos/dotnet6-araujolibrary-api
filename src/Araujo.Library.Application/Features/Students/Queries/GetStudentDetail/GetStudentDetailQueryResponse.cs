using Araujo.Library.Application.Responses;
using System.Collections.Generic;

namespace Araujo.Library.Application.Features.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryResponse : BaseResponse
    {
        public GetStudentDetailQueryResponse() : base()
        {

        }
        public StudentDetailVm Book { get; set; }
    }
}
