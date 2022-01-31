using Araujo.Library.Application.Contracts.Persistence;
using Araujo.Library.Persistence.DbContexts;
using Araujo.Library.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Araujo.Library.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AraujoDbContext>(options =>
            options.UseInMemoryDatabase("AraujoLibrary"));
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
