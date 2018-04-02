using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MountainBound.Areas.Admin.Models;
using MountainBound.Areas.Campfire.Models;
using MountainBound.Areas.Trailhead.Models;
using MountainBound.Models;
using MountainBound.Areas.TradingPost.Models;
using Message = Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging.Message;

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
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<AppIdentityDbContext>(opts =>
                opts.UseSqlServer(_config["IdentityConnectionStrings:DefaultConnection"]));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();
            services.AddSingleton<ITrailRepository, TrailMemoryRepository>();
            services.AddTransient<INationalParkApiRepository, NationalParkRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<MessageRepository>();

            services.AddLogging();
            services.AddMvc();
            services.AddSession();
            services.AddMemoryCache();

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
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name:"area", template:"{area:exists}/{controller=Home}/{action=Index}/{id?}");


                routes.MapRoute(name: "default", template:"{controller=Home}/{action=Index}/{id?}");


            });
            
        }
        
    }
}
