using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
  public   class commissionServices:IcommissionServices
    {
        private readonly ApplicationDbContext _context;
        public commissionServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(commission obj)
        {
            await _context.commission.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var country = GetById(id);
            country.isdeleted = true;
            _context.commission.Update(country);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<commission> GetAll() => _context.commission.Where(x => x.isdeleted == false).ToList();

        public commission GetById(int id) =>
            _context.commission.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(commission obj)
        {
            _context.commission.Update(obj);
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
