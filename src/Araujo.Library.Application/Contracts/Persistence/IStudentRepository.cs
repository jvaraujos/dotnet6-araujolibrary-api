using Araujo.Library.Domain.Entities;
using System.Threading.Tasks;

namespace Araujo.Library.Application.Contracts.Persistence
{
    public interface IStudentRepository : IAsyncRepository<Student>
    {
        Task<Student> GetStudentByEmailAsync(string email);
    }

}
