using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using plathora.Entity;

namespace plathora.Persistence
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       public  DbSet<AffiltateRegistration> affiltateRegistrations { get; set; }
        public DbSet<CountryRegistration> CountryRegistrations { get; set; }
        public DbSet<StateRegistration> StateRegistrations { get; set; }
        public DbSet<CityRegistration> cityRegistrations { get; set; }
        public DbSet<CustomerRegistration> CustomerRegistration { get; set; }
        public DbSet<SectorRegistration> SectorRegistration { get; set; }
        public DbSet<BankRegistration> BankRegistration { get; set; }

        public DbSet<BusinessRegistration> BusinessRegistration { get; set; }
        public DbSet<PackageRegistration> PackageRegistration { get; set; }
        public DbSet<BusinessPackage> BusinessPackage { get; set; }
        public DbSet<Advertise > Advertise { get; set; }
        public DbSet<tax> tax { get; set; }
        public DbSet<Taluka> Taluka { get; set; }
        public DbSet<ProductMaster> ProductMaster { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<commission> commission { get; set; }
        public DbSet<AffilatePackage> AffilatePackage { get; set; }
        public DbSet<BusinessOwnerRegi> BusinessOwnerRegi { get; set; }
        public DbSet<emp> emp { get; set; }
        public DbSet<ModuleMaster> moduleMasters { get; set; }
        public DbSet<Videos> videos { get; set; }

        public DbSet<advertisementInfo> advertisementInfos { get; set; }
        public DbSet<social> socials { get; set; }
        public DbSet<socialdetails> socialdetails { get; set; }
        public DbSet<slider> sliders { get; set; }
        public DbSet<distance> distance { get; set; }
        public DbSet<rating> ratings { get; set; }
        public DbSet<businessrating> businessratings { get; set; }
        public DbSet<tblfeedback> tblfeedback { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Subscribe> Subscribe { get; set; }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ContactUs> ContactUs  { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<dashboardTable> dashboardTable { get; set; }
        public DbSet<referfriendSlider> referfriendSlider { get; set; }
        public DbSet<PassiveCommission> PassiveCommission { get; set; }
        //public DbSet<Advadd-migrationertisementDetails> advertisementDetails { get; set; }
        //public DbSet<advertisementtest> advertisementtest { get; set; }

    }
}
