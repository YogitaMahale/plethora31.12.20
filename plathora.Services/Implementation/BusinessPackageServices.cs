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
 public    class BusinessPackageServices: IBusinessPackageServices
    {
        private readonly ApplicationDbContext _context;
        public BusinessPackageServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(BusinessPackage obj)
        {
            await _context.BusinessPackage.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

      

        public async Task Delete(int id)
        {
            var business = GetById(id);
            business.isdeleted = true;
            _context.BusinessPackage.Update(business);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<BusinessPackage> GetAll() => _context.BusinessPackage.Where(x => x.isdeleted == false).ToList();

        public IEnumerable<SelectListItem> GetAllState(int businessid)
        {
            throw new NotImplementedException();
        }

        public BusinessPackage GetById(int id) =>
            _context.BusinessPackage.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(BusinessPackage obj)
        {
            _context.BusinessPackage.Update(obj);
            await _context.SaveChangesAsync();
        }

        

    }
}
