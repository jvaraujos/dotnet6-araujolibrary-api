using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Domain.Entities;
using Araujo.Library.Persistence.DbContexts;

namespace Araujo.Library.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(AraujoDbContext context) : base(context)
        {
        }
    }
}
