using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeVigilancia.Common.Database.Models;
using SistemaDeVigilancia.Service;
using System;
using System.Net;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Logging;

namespace SistemaDeVigilancia_API
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
            services.AddSwaggerGen(options => {
                options.DescribeAllEnumsAsStrings();
                options.DescribeStringEnumsInCamelCase();
                options.SwaggerDoc("v1", new Info {
                    Title = "API",
                    Version = "v1",
                    Description = "Description"
                });
            });
            services.AddMvc();

            services.Configure<TelegramConfiguration>(Configuration.GetSection("Telegram"));

            services.AddDbContext<SistemaDeVigilanciaContext>(options => options.UseInMemoryDatabase("SistemaDeVigilancia"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }
            
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger().UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "HTTP API V1"); });
        }
    }
}
