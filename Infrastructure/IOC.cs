using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class IOC
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddTransient<IPersonService, PersonService>();

            services.AddTransient<IQueueLineService, QueueLineService>();

            services.AddTransient<IQueuePersonService, QueuePersonService>();

            services.AddTransient<IPersonConditionService, PersonConditionService>();

            services.AddTransient<IEnqueueService, EnqueueService>();

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>(options
                => options.UseSqlServer(config.GetConnectionString("defaultConnection")));

            return services;
        }
    }
}
