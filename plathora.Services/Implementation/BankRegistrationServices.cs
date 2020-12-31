using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services.Implementation
{
   public class BankRegistrationServices:IBankRegistrationServices
    {
        private readonly ApplicationDbContext _context;
        public BankRegistrationServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(BankRegistration obj)
        {
            await _context.BankRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int sectorid)
        {
            var objsector = GetById(sectorid);
            objsector.isdeleted = true;
            _context.BankRegistration.Update(objsector); 
            await _context.SaveChangesAsync();
        }
        public IEnumerable<BankRegistration> GetAll() => _context.BankRegistration.Where(x => x.isdeleted == false).ToList();

        public BankRegistration GetById(int sectorid) =>
            _context.BankRegistration.Where(x => x.id == sectorid).FirstOrDefault();

        public async Task UpdateAsync(BankRegistration obj)
        {
            _context.BankRegistration.Update(obj);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllBank()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.name,
                Value = emp.id.ToString()
            });
        }
    }
}