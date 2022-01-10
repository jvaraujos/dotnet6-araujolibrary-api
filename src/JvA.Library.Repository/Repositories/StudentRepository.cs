using JvA.Library.Application.Contracts.Persistence;
using JvA.Library.Domain.Entities;
using JvA.Library.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JvA.Library.Persistence.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(JvADbContext context) : base(context)
        {
        }

        public async Task<Student> GetStudentByEmailAsync(string email)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
