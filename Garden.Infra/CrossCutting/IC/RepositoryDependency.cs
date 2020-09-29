using Garden.Domain.Interfaces;
using Garden.Infra.Data.Configuration;
using Garden.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Garden.Infra.CrossCutting.IC
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseFactory, DatabaseFactory>();
            services.AddScoped<IRepositoryHarvest, HarvestRepository>();
            services.AddScoped<IRepositorySpecie, SpecieRepository>();
            services.AddScoped<IRepositoryGroupTree, GroupTreeRepository>();
            services.AddScoped<IRepositoryTree, TreeRepository>();
        }
    }
}
