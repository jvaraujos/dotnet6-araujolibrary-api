using System;
using System.Collections.Generic;
using System.Text;

namespace JvA.Library.Domain.Entities
{
    public class CourseCategories
    {
        public Guid CourseId { get; set; }
        public Course Course { get; set; }
        public Guid BookCategoryId { get; set; }
        public BookCategory BookCategory { get; set; }
    }
}
