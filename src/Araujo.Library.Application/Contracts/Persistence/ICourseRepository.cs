using Araujo.Library.Domain.Entities;

namespace Araujo.Library.Application.Contracts.Persistence
{
    public interface ICourseRepository : IAsyncRepository<Course>
    {
    }
}
