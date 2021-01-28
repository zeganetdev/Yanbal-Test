using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace Yanbal.Examen.MVC.MainContext
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            db.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
