using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;

namespace JvA.Library.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IBookRepository> GetBookRepository()
        {
            var bookCategoryTiGuid = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE");
            var bookCategoryEngenhariaCivilGuid = Guid.Parse("6313179F-7837-473A-A4D5-A5571B43E6A6");

            var books = new List<Book>
            {
                new Book
                {
                    Id = Guid.NewGuid(),
                Author = "Uncle Bob",
                Title = "Clean Code",
                Publisher = "Atlas",
                Pages = 429,
                BookCategoryId= bookCategoryTiGuid
                },
                new Book
                {
                     Id = Guid.NewGuid(),
                Author = "Andrew Hunt",
                Title = "Pragmatic Programmer",
                Publisher = "Addison-Wesley Professional",
                Pages = 352,
                BookCategoryId = bookCategoryTiGuid
                },
                new Book
                {
                    Id = Guid.NewGuid(),
                Author = "Hélio Alves de Azeredo",
                Title = "O edifício até sua cobertura",
                Publisher = "Blucher",
                Pages = 193,
                BookCategoryId = bookCategoryEngenhariaCivilGuid
                },
                new Book
                {
                     Id = Guid.NewGuid(),
                Author = "Manoel Henrique Campos",
                Title = "Concreto armado: eu te amo",
                Publisher = "Blucher",
                Pages = 652,
                BookCategoryId=bookCategoryEngenhariaCivilGuid
                }
            };

            var mockBookRepository = new Mock<IBookRepository>();
            mockBookRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(books);
            mockBookRepository.Setup(repo => repo.GetAllBooksPagedResponseByAvaliableAsync(1, 25, true)).ReturnsAsync(books);

            mockBookRepository.Setup(repo => repo.AddAsync(It.IsAny<Book>())).ReturnsAsync(
                (Book book) =>
                {
                    books.Add(book);
                    return book;
                });

            return mockBookRepository;
        }
    }
}
