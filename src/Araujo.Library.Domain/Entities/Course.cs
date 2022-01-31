using Araujo.Library.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Araujo.Library.Domain.Entities
{
    public class Course : AuditableEntity
    {

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookCategory> BookCategories { get; set; }

    }
}
