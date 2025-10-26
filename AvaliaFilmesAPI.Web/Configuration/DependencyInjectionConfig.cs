using AvaliaFilmesAPI.Business.Service;
using AvaliaFilmesAPI.Business.Service.Interface;
using AvaliaFilmesAPI.Data.Repositories;
using AvaliaFilmesAPI.Data.Repositories.InterfaceRepository;

namespace AvaliaFilmesAPI.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IDescricaoFilmeGemini, DescricaoFilmeGemini>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();

            return services;
        }
    }

}