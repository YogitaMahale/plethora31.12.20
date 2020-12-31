using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services.Implementation
{
  public  class TalukaServices:ITalukaServices
    {
        private readonly ApplicationDbContext _context;
        public TalukaServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Taluka obj)
        {
            await _context.Taluka.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.Taluka.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Taluka> GetAll() => _context.Taluka.Where(x => x.isdeleted == false).ToList();
        public Taluka getbyid(int id) =>
            _context.Taluka.Where(x => x.id == id).FirstOrDefault();

        public Taluka GetById(int id) =>
            _context.Taluka.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(Taluka obj)
        {
            _context.Taluka.Update(obj);
            await _context.SaveChangesAsync();
        }

    }
}
