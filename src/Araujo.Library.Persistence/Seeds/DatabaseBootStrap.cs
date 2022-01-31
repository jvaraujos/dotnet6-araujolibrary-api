using Araujo.Library.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Araujo.Library.Persistence.Seeds
{
    public static class DatabaseBootStrap
    {
        public static void AddDevContext(AraujoDbContext context)
        {
            var bookCategoryTiGuid = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE");
            var bookCategoryEngenhariaCivilGuid = Guid.Parse("6313179F-7837-473A-A4D5-A5571B43E6A6");
            var courseTiGuid = Guid.Parse("BF3F3002-7E53-441E-8B76-F6280BE284AA");
            var courseEngenhariaCivilGuid = Guid.Parse("FE98F549-E790-4E9F-AA16-18C2292A2EE9");

            #region Books
            context.Books.Add(new Domain.Entities.Book
            {
                Id = Guid.NewGuid(),
                Author = "Uncle Bob",
                Title = "Clean Code",
                Publisher = "Atlas",
                Pages = 429,
                BookCategoryId = bookCategoryTiGuid

            });
            context.Books.Add(new Domain.Entities.Book
            {
                Id = Guid.NewGuid(),
                Author = "Andrew Hunt",
                Title = "Pragmatic Programmer",
                Publisher = "Addison-Wesley Professional",
                Pages = 352,
                BookCategoryId = bookCategoryTiGuid

            });
            context.Books.Add(new Domain.Entities.Book
            {
                Id = Guid.NewGuid(),
                Author = "Hélio Alves de Azeredo",
                Title = "O edifício até sua cobertura",
                Publisher = "Blucher",
                Pages = 193,
                BookCategoryId = bookCategoryEngenhariaCivilGuid

            });
            context.Books.Add(new Domain.Entities.Book
            {
                Id = Guid.NewGuid(),
                Author = "Manoel Henrique Campos",
                Title = "Concreto armado: eu te amo",
                Publisher = "Blucher",
                Pages = 652,
                BookCategoryId = bookCategoryEngenhariaCivilGuid
            });
            #endregion

            #region BookCategories
            context.BookCategories.Add(new Domain.Entities.BookCategory
            {
                Id = bookCategoryTiGuid,
                Name = "TI"
            });
            context.BookCategories.Add(new Domain.Entities.BookCategory
            {
                Id = bookCategoryEngenhariaCivilGuid,
                Name = "Engenharia Civil"
            });
            #endregion

            #region Courses
            context.Courses.Add(new Domain.Entities.Course
            {
                Id = courseTiGuid,
                Name = "Sistemas de Infomração",
            });
            context.Courses.Add(new Domain.Entities.Course
            {
                Id = courseEngenhariaCivilGuid,
                Name = "Engenharia Civil",
            });
            #endregion

            #region CourseCategories
            context.CourseCategories.Add(new Domain.Entities.CourseCategories
            {
                CourseId = courseTiGuid,
                BookCategoryId = bookCategoryTiGuid
            });
            context.CourseCategories.Add(new Domain.Entities.CourseCategories
            {
                CourseId = courseEngenhariaCivilGuid,
                BookCategoryId = bookCategoryEngenhariaCivilGuid
            });
            #endregion

            #region Students
            context.Students.Add(new Domain.Entities.Student
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Email = "hdinizribeiro@gmail.com",
                CourseId = courseTiGuid
            });
            context.Students.Add(new Domain.Entities.Student
            {
                Id = Guid.NewGuid(),
                Name = "Zezinho",
                Email = "zezinho@domain.com",
                CourseId = courseEngenhariaCivilGuid
            });
            context.Students.Add(new Domain.Entities.Student
            {
                Id = Guid.NewGuid(),
                Name = "Luizinho",
                Email = "luizinho@domain.com",
                CourseId = courseEngenhariaCivilGuid
            });
            #endregion

            context.SaveChanges();
        }
    }
}
