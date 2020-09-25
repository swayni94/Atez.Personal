using System;
using Atez.Personal.Data;
using Atez.Personal.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Atez.Personal.Api
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

            services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(option => option.UseNpgsql(Configuration["Data:DbContext:AtezPersonalConnectionString"]));
            services.AddControllers();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();

            services.AddSwaggerGen(c =>
            {
                
                c.SwaggerDoc("CoreSwagger", new OpenApiInfo
                {
                    Title = "Atez Personal",
                    Version = "1.0.0",
                    Description = "Atez Personel Challenge 2020",
                    Contact = new OpenApiContact()
                    {
                        Name = "Sercan Vayni",
                        Url = new Uri("http://sercanvayni.com"),
                        Email = "sercanvayni@hotmail.com"
                    },
                    TermsOfService = new Uri("http://swagger.io/terms/")
                });


            });

            ////services.AddDbContext<WayniCmsDataContext>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                //TODO: Either use the SwaggerGen generated Swagger contract (generated from C# classes)
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json", "Swagger Test .Net Core");

                //TODO: Or alternatively use the original Swagger contract that's included in the static files
                // c.SwaggerEndpoint("/swagger-original.json", "Swagger Petstore Original");
            });

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
