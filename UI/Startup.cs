using BLL.Filters;
using BLL.Mapper;
using BLL.Service.CategoryServices;
using BLL.Service.ClientServices;
using BLL.Service.CompanyServices;
using BLL.Service.SalesInvoceServices;
using BLL.Service.SalesReportServices;
using BLL.Service.SpecyServices;
using BLL.Service.UnitServices;
using DAL.Data;
using DAL.Repository.CategoryRepository;
using DAL.Repository.ClientRepository;
using DAL.Repository.CompanyRepository;
using DAL.Repository.SalesInvoceRepository;
using DAL.Repository.SalesReportRepository;
using DAL.Repository.SpecyRepository;
using DAL.Repository.UnitRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
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
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyServices, CompanyServices>();
            services.AddScoped<ISpecyRepository, SpecyRepository>();
            services.AddScoped<ISpecyServices, SpecyServices>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUnitServices, UnitServices>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientServices, ClientServices>();
            services.AddScoped<ISalesInvoceServices, SalesInvoceServices>();
            services.AddScoped<ISalesInvoceRepository, SalesInvoceRepository>();
            services.AddScoped<ISalesReportServices, SalesReportServices>();
            services.AddScoped<ISalesReportRepository, SalesReportRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddControllersWithViews();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
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
                    pattern: "{controller=Home}/{action=index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
