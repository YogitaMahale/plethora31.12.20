using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
    public class socialsServices: IsocialsServices
    {
        private readonly ApplicationDbContext _context;
        public socialsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(social obj)
        {
            await _context.socials.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.socials.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<social> GetAll() => _context.socials.Where(x => x.isdeleted == false).ToList();



        public social GetById(int id) =>
            _context.socials.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(social obj)
        {
            _context.socials.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
