using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.PersistenceDB.Context;
using EventManagerAPI.Extensions;
using EventManagerAPI.Infrastructure.Mappings;
using EventManagerAPI.Middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.Extensions;
using ServiceLayer.Models;

namespace EventManagerAPI
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers().AddFluentValidation(cf=> cf.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddHttpContextAccessor();
            services.AddServices();
            services.AddTokenAuthentication(_configuration);

            services.AddDbContext<EventManagerDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), s=>s.MigrationsAssembly("EventManagerAPI")));
            services.Configure<JWTConfiguration>(_configuration.GetSection(nameof(JWTConfiguration)));
            services.AddScoped<DbContext, EventManagerDbContext>();
            services.AddMappings();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddSwaggerGenConfig();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider versionDescProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<CultureMiddleware>();
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                foreach (var item in versionDescProvider.ApiVersionDescriptions)
                {
                    x.SwaggerEndpoint($"/swagger/" +
                        $"LibraryOpenAPISpecification{item.GroupName}/swagger.json",
                        item.GroupName.ToUpperInvariant());
                }


            });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
