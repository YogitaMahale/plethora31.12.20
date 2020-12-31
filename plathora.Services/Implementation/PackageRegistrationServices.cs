using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace plathora.Services.Implementation
{
   public  class PackageRegistrationServices:IPackageRegistrationServices
    {
        private readonly ApplicationDbContext _context;
        public PackageRegistrationServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(PackageRegistration obj)
        {
            await _context.PackageRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

     
        public IEnumerable<PackageRegistration> GetAll() => _context.PackageRegistration.Where(x => x.isdeleted == false).ToList();

        public PackageRegistration  GetById(int pkgid) =>
            _context.PackageRegistration.Where(x => x.id == pkgid).FirstOrDefault();

        public async Task UpdateAsync(PackageRegistration obj)
        {
            _context.PackageRegistration .Update(obj);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllPackage()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.name,
                Value = emp.id.ToString()
            });
        }
        public async Task Delete(int pkgid)
        {
            var objsector = GetById(pkgid);
            objsector.isdeleted = true;
            _context.PackageRegistration.Update(objsector);
            await _context.SaveChangesAsync();
        }
    }
}