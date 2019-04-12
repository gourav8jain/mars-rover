using MarsRoverApp.BusinessLogic.Implementation;
using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.WebApi.Implementation.Caching;
using MarsRoverApp.WebApi.Implementation.Filters;
using MarsRoverApp.WebApi.Implementation.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace MarsRoverApp.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config => { config.Filters.Add(typeof(CustomExceptionFilter)); });
            services.AddScoped<IRoverCaching, RoverCaching>();
            services.AddScoped<IRover, Rover>();
            services.AddScoped<IValidator, Validator>();
            services.AddScoped<InputValidationFilter>();
            services.AddMemoryCache();
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi3();
            loggerFactory.AddNLog();
        }
    }
}
