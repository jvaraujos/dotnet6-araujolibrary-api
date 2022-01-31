using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Domain.Entities;
using Araujo.Library.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Araujo.Library.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AraujoDbContext context) : base(context)
        {
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
