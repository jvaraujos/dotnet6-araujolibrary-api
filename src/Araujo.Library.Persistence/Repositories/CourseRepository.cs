using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using JvA.Library.Persistence.DbContexts;

namespace JvA.Library.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AraujoDbContext context) : base(context)
        {
        }
    }
}
