using Inmobiliaria.Domain.Interfaces;
using Inmobiliaria.Domain.UseCase;
using Inmobiliaria.Domain.UseCase.Interfaces;
using Inmobiliaria.Infraestructura.Repository;

namespace Inmobiliaria.Api.Resource
{
    public static class ServiceCollections
    {
        public static void AddCommonLayer(this IServiceCollection services) {

            services.AddTransient<Ipropiedades, PropiedadesUsecase>();
            services.AddTransient<IPropiedadesRepos, PropiedadRepository>();

        }
    }
}
