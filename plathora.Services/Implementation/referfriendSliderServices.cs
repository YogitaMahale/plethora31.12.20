using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
  public  class referfriendSliderServices : IreferfriendSliderServices
    {
        private readonly ApplicationDbContext _context;
        public referfriendSliderServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(referfriendSlider obj)
        {
            await _context.referfriendSlider.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.referfriendSlider.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<referfriendSlider> GetAll() => _context.referfriendSlider.Where(x => x.isdeleted == false).ToList();
        public referfriendSlider getbyid(int id) =>
            _context.referfriendSlider.Where(x => x.id == id).FirstOrDefault();

        public referfriendSlider GetById(int id) =>
            _context.referfriendSlider.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(referfriendSlider obj)
        {
            _context.referfriendSlider.Update(obj);
            await _context.SaveChangesAsync();
        }
        
    }
}
