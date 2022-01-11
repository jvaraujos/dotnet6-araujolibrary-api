using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using JvA.Library.Persistence.DbContexts;

namespace JvA.Library.Persistence.Repositories
{
    public class BookCategoryRepository : BaseRepository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(AraujoDbContext context) : base(context)
        {

        }
    }
}
