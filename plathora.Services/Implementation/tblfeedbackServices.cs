using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
  public  class tblfeedbackServices:ItblfeedbackServices
    {
        private readonly ApplicationDbContext _context;
        public tblfeedbackServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(tblfeedback obj)
        {
            await _context.tblfeedback.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.tblfeedback.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<tblfeedback> GetAll() => _context.tblfeedback.Where(x => x.isdeleted == false).ToList();



        public tblfeedback GetById(int id) =>
            _context.tblfeedback.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(tblfeedback obj)
        {
            _context.tblfeedback.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
