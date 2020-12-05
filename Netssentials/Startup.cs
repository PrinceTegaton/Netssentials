using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Netssentials.Core.DataAccess;
using Netssentials.Core.Managers;
using Netssentials.Core.Models;
using Netssentials.Core.Repository;

namespace Netssentials
{
    public partial class Startup
    {
        // obj to hold dynamic config values
        public Settings _settings { get; set; } = new Settings();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDI(services);
            ConfigureIdentity(services);

            string connStr = Configuration.GetConnectionString("SqlServerDB");
            services.AddDbContext<SqlServerDbContext>(opt =>
                      opt.UseSqlServer(connStr, builder =>
                      {
                          builder.UseRowNumberForPaging();
                      }));

            if (_settings.EnableSwagger)
                services.AddSwaggerGen();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (_settings.EnableSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", this.GetType().Assembly.GetName().Name));
            }

            if (_settings.EnableHttps)
                app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
