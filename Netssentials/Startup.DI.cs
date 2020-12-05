using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netssentials.Core.DataAccess;
using Netssentials.Core.Managers;
using Netssentials.Core.Models;
using Netssentials.Core.Repository;

namespace Netssentials
{
    public partial class Startup
    {
        public void ConfigureDI(IServiceCollection services)
        {
            Configuration.Bind(nameof(Settings), _settings);
            services.AddSingleton(_settings);

            // repo
            services.AddTransient<DbContext, SqlServerDbContext>();
            services.AddScoped(typeof(ISimpleRepository<>), typeof(SimpleRepository<>));

            services.AddTransient<ISimpleRepository<Contact>, SimpleRepository<Contact>>();
            services.AddTransient<ISimpleRepository<Address>, SimpleRepository<Address>>();

            services.AddTransient<IContactManager, ContactManager>();

            //services.AddTransient<IRextHttpClient, RextHttpClient>();
        }
    }
}
