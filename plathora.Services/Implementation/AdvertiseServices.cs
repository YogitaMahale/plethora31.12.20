using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
  public  class AdvertiseServices : IAdvertiseServices
    {
        private readonly ApplicationDbContext _context;
        public AdvertiseServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Advertise obj)
        {
            await _context.Advertise.AddAsync(obj);
            await _context.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.Advertise.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Advertise> GetAll() => _context.Advertise.Where(x => x.isdeleted == false).ToList();

     

        public Advertise GetById(int id) =>
            _context.Advertise.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(Advertise obj)
        {
            _context.Advertise.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
