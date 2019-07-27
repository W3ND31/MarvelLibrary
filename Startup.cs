using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Models;
using MarvelLibrary.Data;
using MarvelLibrary.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MarvelLibrary
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddDbContext<MarvelLibraryContext>(options =>options.UseMySql(Configuration.GetConnectionString("MarvelLibraryContext"), builder => builder.MigrationsAssembly("MarvelLibrary")));
            services.AddDbContext<MarvelLibraryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MarvelLibraryContext"), builder => builder.MigrationsAssembly("MarvelLibrary")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Home/Index/";
            });

            services.AddScoped<CharacterService>();
            services.AddScoped<FavService>();
            services.AddScoped<RestServices>();
            services.AddScoped<ComicService>();
            services.AddScoped<AccountService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<HttpContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
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
            app.UseCookiePolicy();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Accounts}/{action=Login}/{id?}");
            });
        }
    }
}
