using AgroNepalTrade.Data;
using AgroNepalTrade.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FYP_AgroNepalTrade.Models.Services;
using FYP_AgroNepalTrade.BlogManagers;
using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using FYP_AgroNepalTrade.Authorization;
using FYP_AgroNepalTrade.ProductManagers;
using FYP_AgroNepalTrade.ProductManagers.Interfaces;

namespace FYP_AgroNepalTrade
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultUI()
            .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IBlogBusinessManager, BlogBusinessManager>();
            services.AddScoped<IAuthorBusinessManager, AuthorBusinessManager>();
            services.AddScoped<IBlogHomeBusinessManager, BlogHomeBusinessManager>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IProductBusinessManager, ProductBusinessManager>();
            services.AddScoped<IFarmerBusinessManager, FarmerBusinessManager>();
            services.AddScoped<IFarmerHomeBusinessManager, FarmerHomeBusinessManager>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddTransient<IAuthorizationHandler, BlogAuthorizatioHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
