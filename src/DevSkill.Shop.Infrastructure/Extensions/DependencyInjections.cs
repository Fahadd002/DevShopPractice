using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Infrastructure.Data.Migrations;
using DevSkill.Shop.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevSkill.Shop.Infrastructure.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            return services;
        }
    }
}
