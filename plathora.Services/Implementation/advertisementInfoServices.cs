using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
   public  class advertisementInfoServices : IadvertisementInfoServices
    {
        private readonly ApplicationDbContext _context;
        public advertisementInfoServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(advertisementInfo obj)
        {
            await _context.advertisementInfos.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.advertisementInfos.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<advertisementInfo> GetAll() => _context.advertisementInfos.Where(x => x.isdeleted == false).ToList();



        public advertisementInfo GetById(int id) =>
            _context.advertisementInfos.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(advertisementInfo obj)
        {
            _context.advertisementInfos.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
