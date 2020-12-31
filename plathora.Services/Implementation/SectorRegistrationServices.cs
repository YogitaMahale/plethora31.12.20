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
  public   class SectorRegistrationServices:ISectorRegistrationServices
    {
        private readonly ApplicationDbContext _context;
        public SectorRegistrationServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(SectorRegistration obj)
        {
            await _context.SectorRegistration.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int sectorid)
        {
            var objsector = GetById(sectorid);
            objsector.isdeleted = true;
            _context.Update(objsector); 
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SectorRegistration> GetAll() => _context.SectorRegistration.Where(x => x.isdeleted == false).ToList();

        public SectorRegistration GetById(int sectorid) =>
            _context.SectorRegistration.Where(x => x.id == sectorid).FirstOrDefault();

        public async Task UpdateAsync(SectorRegistration obj)
        {
            _context.SectorRegistration.Update(obj);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<SelectListItem> GetAllsector()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.name ,
                Value = emp.id.ToString()
            });
        }
    }
} 