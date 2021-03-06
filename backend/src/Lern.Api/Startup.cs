using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Lern.Core;
using Lern.Core.Configuration;
using Lern.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Lern.Api
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
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CORS",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddJwtDefault(Configuration);
            services.AddValidators();
            services.AddSwaggerDoc();
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new DefaultInfrastructureModule(
                Environment.GetEnvironmentVariable("POSTGRES_STRING") ?? Configuration["ConnectionString"],
                new CloudinaryConfiguration
                {
                    Cloud = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD") ?? Configuration["Cloudinary:Cloud"],
                    ApiKey = Environment.GetEnvironmentVariable("CLOUDINARY_APIKEY") ?? Configuration["Cloudinary:ApiKey"],
                    ApiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_APISECRET") ?? Configuration["Cloudinary:ApiSecret"]
                },
                new AzureComputerVisionConfiguration
                {
                    SubscriptionKey = Environment.GetEnvironmentVariable("AZURE_SUBSCRIPTIONKEY") ?? Configuration["AzureComputerVision:SubscriptionKey"],
                    Endpoint = Environment.GetEnvironmentVariable("AZURE_ENDPOINT") ?? Configuration["AzureComputerVision:Endpoint"]
                }
            ));
            containerBuilder.RegisterModule(new DefaultCoreModule(Configuration));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lern.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CORS");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}