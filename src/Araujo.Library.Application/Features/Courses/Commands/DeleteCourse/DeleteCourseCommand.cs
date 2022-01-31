using MediatR;
using System;

namespace Araujo.Library.Application.Features.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest
    {
        public DeleteCourseCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
