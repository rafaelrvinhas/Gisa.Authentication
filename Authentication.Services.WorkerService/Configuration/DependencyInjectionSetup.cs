using Authentication.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Services.WorkerService.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<App>();

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
