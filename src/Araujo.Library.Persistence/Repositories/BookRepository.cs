using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using JvA.Library.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JvA.Library.Persistence.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(AraujoDbContext context) : base(context)
        {

        }
        public async Task<IReadOnlyList<Book>> GetAllBooks()
        {
            var books = await _dbContext.Books.ToListAsync();
            return books;
        }
        public async Task BorrowBook(Guid id, string studentEmail)
        {
            var book = await _dbContext.Books.FirstAsync(x => x.Id == id);
            var student = await _dbContext.Students.FirstAsync(x => x.Email == studentEmail);
            book.LentToStudentId = student.Id;
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Book>> GetAllBooksPagedResponseByAvaliableAsync(int page, int size, bool avaliable)
        {
            var allBooks = await _dbContext.Books
                .Where(x => avaliable ? x.LentToStudentId == null : x.LentToStudentId != null)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();
            return allBooks;
        }
        public async Task<bool> BorrowBookAvaliableToStudentEmail(Guid id, string studentEmail)
        {
            var student = await _dbContext
                .Students
                .Include(x => x.Course)
                .FirstAsync(x => x.Email == studentEmail);

            var book = await _dbContext.Books
                 .Include(x => x.BookCategory)
                 .FirstAsync(x => x.Id == id);
            var courseCategories = await _dbContext.CourseCategories.FirstOrDefaultAsync(x =>
            x.CourseId == student.CourseId &&
            x.BookCategoryId == book.BookCategoryId);

            if (courseCategories != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsBookUnique(string title,string author)
        {
            return await _dbContext.Books.AsNoTracking().AnyAsync(x => x.Title.ToLower() == title.ToLower() && x.Author.ToLower() == author.ToLower());
        }
    }
}
