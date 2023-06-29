using Authentication.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Services.Api.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<AuthenticationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AuthenticationDbConnection")));
        }
    }
}
