using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using plathora.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using plathora.Services;
using plathora.Services.Implementation;
using plathora.Entity;
using appFoodDelivery.Services.Implementation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Identity.UI.Services;
using plathora.Utility;

namespace plathora
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





            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //  .AddEntityFrameworkStores<ApplicationDbContext>()
            // .AddDefaultTokenProviders()
            //   .AddDefaultUI();




            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
             .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddSingleton<IEmailSender, EmailSender>();

           
            services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            // services.AddScoped<IAffiltateRegistrationService, AffiltateRegistrationService>();
            services.AddScoped<IAffiltateRegistrationService, AffiltateRegistrationService>();
            services.AddScoped<ICountryRegistrationservices , CountryRegistrationServices>();
            services.AddScoped<IStateRegistrationService, StateRegistrationService>();
            services.AddScoped<ICityRegistrationservices, CityRegistrationservices >();
            services.AddScoped<ICustomerRegistrationservices, CustomerRegistrationservices>();
            services.AddScoped<ISectorRegistrationServices, SectorRegistrationServices>();
            services.AddScoped<IBankRegistrationServices, BankRegistrationServices>();
            services.AddScoped<IBusinessRegistrationServieces , BusinessRegistrationServieces >();
            services.AddScoped<IPackageRegistrationServices, PackageRegistrationServices>();
            services.AddScoped<IBusinessPackageServices, BusinessPackageServices>();
            services.AddScoped<IAdvertiseServices, AdvertiseServices>();
            services.AddScoped<ItaxServices , taxServices >();
            services.AddScoped<ITalukaServices, TalukaServices>();
            services.AddScoped<IProductMasterServices , ProductMasterServices >();
            services.AddScoped<IMembershipServices , MembershipServices>();
            services.AddScoped<IcommissionServices, commissionServices>();
            services.AddScoped<IAffilatePackageServices, AffilatePackageServices>();
            services.AddScoped<IBusinessOwnerRegiServices, BusinessOwnerRegiServices>();
            services.AddScoped<ISP_Call, SP_Call>();
            services.AddScoped<IModuleMasterServices, ModuleMasterServices>();
            services.AddScoped<IVideoServices,VideoServices>();
            //services.AddScoped<IadvertiseDetailsServices, advertiseDetailsServices>();
            //services.AddScoped<IadvertisementDetailsServices, advertisementDetailsServices>();
            //services.AddScoped<IadvertisementtestServices,advertisementtestServices>();
            services.AddScoped<IsocialsServices, socialsServices>();
            services.AddScoped<IadvertisementInfoServices, advertisementInfoServices>();
            services.AddScoped<IsliderServices, sliderServices>();
            services.AddScoped<Iratingsservices,ratingsservices>();
            services.AddScoped<IdistanceServices, distanceServices>();
            services.AddScoped<IbusinessratingsServices, businessratingsServices>();
            services.AddScoped<ItblfeedbackServices, tblfeedbackServices>();
            services.AddScoped<IsocialdetailsServices, socialdetailsServices>();

            services.AddScoped<ISubscribeServices, SubscribeServices>();


            services.AddScoped<IContactUsServices, ContactUsServices>();
            services.AddScoped<IAboutUsServices, AboutUsServicesServices>();
            services.AddScoped<INewsServices, NewsServices>();
            services.AddScoped<IreferfriendSliderServices, referfriendSliderServices>();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                    pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
