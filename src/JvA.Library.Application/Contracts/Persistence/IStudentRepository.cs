using JvA.Library.Domain.Entities;
using System.Threading.Tasks;

namespace JvA.Library.Application.Contracts.Persistence
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<Student> GetStudentByEmailAsync(string email);
    }

}
