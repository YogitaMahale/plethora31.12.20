using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
   public  class ModuleMasterServices:IModuleMasterServices
    {
        private readonly ApplicationDbContext _context;
        public ModuleMasterServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ModuleMaster obj)
        {
            await _context.moduleMasters.AddAsync(obj);
            await _context.SaveChangesAsync();
        }



        public async Task Delete(int id)
        {
            var obj = GetById(id);
            obj.isdeleted = true;
            _context.moduleMasters.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<ModuleMaster> GetAll() => _context.moduleMasters.Where(x => x.isdeleted == false).ToList();



        public ModuleMaster GetById(int id) =>
            _context.moduleMasters.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(ModuleMaster obj)
        {
            _context.moduleMasters.Update(obj);
            await _context.SaveChangesAsync();
        }



    }
}
