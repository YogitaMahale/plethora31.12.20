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
 public   class MembershipServices:IMembershipServices
    {
        private readonly ApplicationDbContext _context;
        public MembershipServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Membership  obj)
        {
            await _context.Membership.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var country = GetById(id);
            country.isdeleted = true;
            _context.Membership.Update(country);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Membership> GetAll() => _context.Membership.Where(x => x.isdeleted == false).ToList();

        public Membership GetById(int id) =>
            _context.Membership.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(Membership obj)
        {
            _context.Membership.Update(obj);
            await _context.SaveChangesAsync();
        }

        //public IEnumerable<SelectListItem> GetAllCountry()
        //{
        //    return GetAll().Select(emp => new SelectListItem()
        //    {
        //        Text = emp.countryname,
        //        Value = emp.id.ToString()
        //    });
        //}
    }
}
