using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
  public  class sliderServices:IsliderServices
    {
        private readonly ApplicationDbContext _context;
        public sliderServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(slider obj)
        {
            await _context.sliders.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.sliders.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<slider> GetAll() => _context.sliders.Where(x => x.isdeleted == false).ToList();
        public slider getbyid(int id) =>
            _context.sliders.Where(x => x.id == id).FirstOrDefault();

        public slider GetById(int id) =>
            _context.sliders.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(slider obj)
        {
            _context.sliders.Update(obj);
            await _context.SaveChangesAsync();
        }
        
    }
}
