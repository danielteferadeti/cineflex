using BlogApp.Application.Contracts.Persistence;
using BlogApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CineFlexDbContex>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("BlogAppConnectionString")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
