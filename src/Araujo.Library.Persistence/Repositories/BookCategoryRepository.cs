using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Domain.Entities;
using Araujo.Library.Persistence.DbContexts;

namespace Araujo.Library.Persistence.Repositories
{
    public class BookCategoryRepository : BaseRepository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(AraujoDbContext context) : base(context)
        {

        }
    }
}
