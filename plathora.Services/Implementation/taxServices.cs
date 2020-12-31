using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace plathora.Services.Implementation
{
  public   class taxServices:ItaxServices
    {
        private readonly ApplicationDbContext _context;
        public taxServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(tax obj)
        {
            await _context.tax .AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var objsector = GetById(id);
            objsector.isdeleted = true;
            _context.tax.Update(objsector);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<tax> GetAll() => _context.tax.Where(x => x.isdeleted == false).ToList();

        public tax GetById(int id) =>
            _context.tax.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(tax obj)
        {
            _context.tax.Update(obj);
            await _context.SaveChangesAsync();
        }

        
    }
}