using System;

namespace JvA.Library.Application.Features.Students.Queries.GetStudentDetail
{
    public class StudentDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CourseId { get; set; }
    }
}
