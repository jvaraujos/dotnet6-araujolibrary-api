using JvA.Library.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JvA.Library.Domain.Entities
{
    public class Book : AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public Guid BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }
        public Guid? LentToStudentId { get; set; }
    }
}
