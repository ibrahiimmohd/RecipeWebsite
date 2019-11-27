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
using RecipeWebsite.Models;
using Microsoft.AspNetCore.Identity;

namespace RecipeWebsite
{
    public class Startup
    {
        //public property
        public IConfiguration Configuration { get; }

        //constructor
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeWebsiteRecipies:ConnectionString"]));

            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeWebsiteIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IRecipeRepository, EFRecipeRepository>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();       

            services.AddMvc();
            //services.AddMemoryCache();
            //services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //wwwroot folder
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Home", action = "Index" });


                routes.MapRoute(name: null, template: "{controller}/{action}/{ID?}");
            });

            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);

        }
    }
}
