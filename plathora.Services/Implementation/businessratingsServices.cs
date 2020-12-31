using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
   public  class businessratingsServices:IbusinessratingsServices
    {
        private readonly ApplicationDbContext _context;
        public businessratingsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(businessrating obj)
        {
            await _context.businessratings.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.businessratings.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<businessrating> GetAll() => _context.businessratings.Where(x => x.isdeleted == false).ToList();



        public businessrating GetById(int id) =>
            _context.businessratings.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(businessrating obj)
        {
            _context.businessratings.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}