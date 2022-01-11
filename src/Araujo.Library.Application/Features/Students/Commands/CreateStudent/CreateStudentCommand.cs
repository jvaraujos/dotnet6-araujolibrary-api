using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace JvA.Library.Application.Features.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<CreateStudentCommandResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CourseId { get; set; }
    }
}
