using Microsoft.EntityFrameworkCore;
using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace plathora.Services.Implementation
{
   public  class BusinessOwnerRegiServices:IBusinessOwnerRegiServices
    {
        private readonly ApplicationDbContext _context;
        public BusinessOwnerRegiServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //public async Task CreateAsync(BusinessOwnerRegi obj)
        //{

        //    await _context.BusinessOwnerRegi.AddAsync(obj);
        //    await _context.SaveChangesAsync();

        //}
        public async Task<int> CreateAsync(BusinessOwnerRegi obj)
        {
            string tt = "";
            try
            {
                await _context.BusinessOwnerRegi.AddAsync(obj);
                await _context.SaveChangesAsync();
                return obj.id;
            }
            catch(Exception obj1)
            {
                tt = obj1.Message+","+obj1.Source;
               
            }
            //string p = tt;
            return 0;
           
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        /*
public async Task Delete(int id)
{
   var affilate = GetById(id);
   affilate.isdeleted = true;
   _context.BusinessOwnerRegi.Update(affilate);
   // _context.Remove(affilate);
   await _context.SaveChangesAsync();

}
*/
        //public IEnumerable<BusinessOwnerRegi> GetAll() => _context.BusinessOwnerRegi.AsNoTracking().Where(x => x.isdeleted == false).ToList();
        public IEnumerable<BusinessOwnerRegi> GetAll() => _context.BusinessOwnerRegi.AsNoTracking().ToList();

        public BusinessOwnerRegi GetById(int id) =>
            _context.BusinessOwnerRegi.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(BusinessOwnerRegi obj)
        {
            _context.BusinessOwnerRegi.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
