using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
   public class socialdetailsServices: IsocialdetailsServices
    {
        private readonly ApplicationDbContext _context;
        public socialdetailsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(socialdetails obj)
        {
            await _context.socialdetails.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.socialdetails.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<socialdetails> GetAll() => _context.socialdetails.Where(x => x.isdeleted == false).ToList();



        public socialdetails GetById(int id) =>
            _context.socialdetails.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(socialdetails obj)
        {
            _context.socialdetails.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
