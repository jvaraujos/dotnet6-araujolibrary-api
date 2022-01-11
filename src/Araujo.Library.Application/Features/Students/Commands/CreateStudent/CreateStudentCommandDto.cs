using System;

namespace JvA.Library.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CourseId { get; set; }
    }
}
