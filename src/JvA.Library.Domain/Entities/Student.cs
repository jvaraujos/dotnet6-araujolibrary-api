using JvA.Library.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JvA.Library.Domain.Entities
{
    public class Student : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

    }
}
