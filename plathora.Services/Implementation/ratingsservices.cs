using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace plathora.Services.Implementation
{
  public class ratingsservices:Iratingsservices
    {
        private readonly ApplicationDbContext _context;
        public ratingsservices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(rating obj)
        {
            await _context.ratings.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }

        public async Task Delete(int id)
        {
            var objsector = GetById(id);
            objsector.isdeleted = true;
            _context.ratings.Update(objsector);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<rating> GetAll() => _context.ratings.Where(x => x.isdeleted == false).ToList();

        public rating GetById(int id) =>
            _context.ratings.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(rating obj)
        {
            _context.ratings.Update(obj);
            await _context.SaveChangesAsync();
        }


    }
}