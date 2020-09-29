using Garden.Domain.Interfaces;
using Garden.Infra.Data.Repository;
using Garden.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Garden.Infra.CrossCutting.IC
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceHarvest, HarvestService>();
            services.AddScoped<IServiceSpecie, SpecieService>();
            services.AddScoped<IServiceGroupTree, GroupTreeService>();
            services.AddScoped<IServiceTree, TreeService>();
        }
    }
}
