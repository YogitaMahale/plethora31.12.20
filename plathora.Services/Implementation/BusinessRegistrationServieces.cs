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
   public  class BusinessRegistrationServieces:IBusinessRegistrationServieces
    {
        private readonly ApplicationDbContext _context;
        public BusinessRegistrationServieces(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(BusinessRegistration obj)
        {
            await _context.BusinessRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

     
        public IEnumerable<BusinessRegistration> GetAll() => _context.BusinessRegistration.Where(x => x.isdeleted == false).ToList();

        public BusinessRegistration  GetById(int businessid) =>
            _context.BusinessRegistration .Where(x => x.id == businessid).FirstOrDefault();

        public async Task UpdateAsync(BusinessRegistration  obj)
        {
            _context.BusinessRegistration .Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllBusiness(int sectorid)
        {
            return GetAll().Where(x => x.sectorid == sectorid).Select(emp => new SelectListItem()
            {
                Text = emp.name,
                Value = emp.id.ToString()
            });
        }
        public async Task Delete(int businessid)
        {
            var business = GetById(businessid);
            business.isdeleted = true;
            _context.BusinessRegistration.Update(business );
            await _context.SaveChangesAsync();
        }

    }
}
