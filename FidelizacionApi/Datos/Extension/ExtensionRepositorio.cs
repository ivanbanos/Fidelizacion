using Datos.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Datos.Extension
{
    public static class ExtensionRepositorio
    {
        public static IServiceCollection AgregarRepositorios(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            return services;
        }
    }
}
