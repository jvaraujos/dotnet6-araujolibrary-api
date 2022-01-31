using MediatR;
using System;

namespace Araujo.Library.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest
    {
        public DeleteStudentCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
