using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MountainBound.Areas.Trailhead.Models;
using MountainBound.Models;

namespace MountainBound
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITrailRepository, TrailMemoryRepository>();
            services.AddTransient<INationalParkApiRepository, NationalParkRepository>();
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]));
            services.AddSession();
            services.AddMemoryCache();
            services.AddLogging();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name:"area", template:"{area:exists}/{controller=Directory}/{action=NationalParks}/{id?}");


                routes.MapRoute(name: "default", template:"{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
