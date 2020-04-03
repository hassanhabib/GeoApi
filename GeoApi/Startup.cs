// ---------------------------------------------------------------
// Copyright (c) PiorSoft, LLC All rights reserved.
// ---------------------------------------------------------------

using GeoApi.Brokers.Logging;
using GeoApi.Brokers.Storage;
using GeoApi.Services;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GeoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            InitializeStorage(services);
            InitializeLoggers(services);
            AddControllersAndJsonConfigurations(services);
            services.AddOData();
            services.AddTransient<IGeoService, GeoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().Count();
            });
        }

        private void InitializeStorage(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StorageBroker>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IStorageBroker, StorageBroker>();
        }

        private static void InitializeLoggers(IServiceCollection services)
        {
            services.AddSingleton<ILoggingBroker, LoggingBroker>();
            services.AddTransient<ILogger, Logger<ILoggingBroker>>();
        }

        private static void AddControllersAndJsonConfigurations(IServiceCollection services)
        {
            services.AddControllers().AddMvcOptions(option =>
                option.MaxIAsyncEnumerableBufferLimit = int.MaxValue)
                    .AddNewtonsoftJson();
        }
    }
}
