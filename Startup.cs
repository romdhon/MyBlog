using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blogger.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogger
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Configuration["DBServer"] ?? "localhost";
            var port = Configuration["DBPort"] ?? "1433";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "Pa55w0rd";
            var database = Configuration["Database"] ?? "Colors";

            // services.AddDbContext<ColorContext>(options => 
            //     options.UseSqlServer($"Server={server},{port}; Initial Catalog={database}; User ID={user}; Password={password}"));

            //for development
            // services.AddDbContext<ColorContext>(options =>
            //     options.UseSqlite(Configuration.GetConnectionString("ColorConstr")));
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddSingleton<IUserRepository, MockUserRepository>();
            services.AddDbContext<ColorContext>(options =>
            {
                var sqlitedb = Configuration.GetConnectionString("ColorSqliteDB");
                var sqldb = Configuration.GetConnectionString("ColorSqlDB");

                if (Environment.IsDevelopment())
                {
                    options.UseSqlite(sqlitedb);
                }
                else
                {
                    options.UseSqlServer(sqldb);
                }
            });
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //set a default page by providing a controller or an action 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Users}/{action=LoginPage}/{id?}");
            });

            //manual route
            // app.UseMvc(route =>
            // {
            //     route.MapRoute("Default", "{controller}/{action}/{id}");
            // });

            PrepDB.PrepPopulation(app);
        }
    }
}
