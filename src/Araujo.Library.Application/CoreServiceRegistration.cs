using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Araujo.Library.Application
{
    public static class CoreServiceRegistration
    {
        public static IServiceCollection AddCoreServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
