using System;
using Autofac;
using Hangfire;
using Hangfire.Common;
using HashtagAggregator.Data.DataAccess.Context;
using HashTagAggregatorConsumer.Service.Configuration;
using HashTagAggregatorConsumer.Service.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace HashTagAggregatorConsumer.Service
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<QueueSettings>(Configuration.GetSection("QueueSettings"));

            var connectionString = Configuration.GetSection("AppSettings:ConnectionString").Value;

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<SqlApplicationDbContext>(
                    options => options.UseSqlServer(connectionString));

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddHangfire(config => config.UseSqlServerStorage(connectionString));

            services.AddMvc();

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()));

            IContainer container = new AutofacModulesConfigurator().Configure(services);
            GlobalConfiguration.Configuration.UseActivator(new AutofacContainerJobActivator(container));

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddDebug();
            loggerFactory.AddSerilog();
        
            var options = new BackgroundJobServerOptions
            {               
                ServerName = "ConsumerServiceServer", 
            };
            app.UseHangfireServer(options);
          
            if (env.IsEnvironment("dev"))
            {
                app.UseHangfireDashboard();

                app.UseDeveloperExceptionPage();
               // accessor.CancelRecurringJobs();
            }

            app.UseMvc();
        }
    }
}