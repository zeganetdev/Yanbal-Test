using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Yanbal.Examen.Application.MainContext.AppServices.Contracts;
using Yanbal.Examen.Application.MainContext.AppServices.Implementations;
using Yanbal.Examen.Application.MainContext.MapperProfiles;
using Yanbal.Examen.Domain.Core;
using Yanbal.Examen.Domain.MainContext.Aggregates.ClienteAgg;
using Yanbal.Examen.Infra.Data.MainContext.Context;
using Yanbal.Examen.Infra.Data.MainContext.Repositories;

namespace Yanbal.Examen.MainContext
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddAutoMapper(typeof(AutoMapperProfile));

            var sqlConnectionString = Configuration.GetConnectionString("ClientConnection");
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
                opt.UseSqlServer(sqlConnectionString);
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClienteAppServices, ClienteAppServices>();
            services.AddTransient<IClienteRepository, ClienteRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            db.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
