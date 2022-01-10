using JvA.Library.Application.Responses;
using System.Collections.Generic;

namespace JvA.Library.Application.Features.Students.Queries.GetStudentDetail
{
    public class GetStudentDetailQueryResponse : BaseResponse
    {
        public GetStudentDetailQueryResponse() : base()
        {

        }
        public StudentDetailVm Book { get; set; }
    }
}
