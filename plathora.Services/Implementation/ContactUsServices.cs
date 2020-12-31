using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
  public  class ContactUsServices : IContactUsServices
    {
        private readonly ApplicationDbContext _context;
        public ContactUsServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAsync(ContactUs obj)
        {
            await _context.ContactUs.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj.id;
        }



        //public async Task Delete(int id)
        //{
        //    var obj = GetById(id);
        //    obj.isdeleted = true;
        //    _context.Advertise.Update(obj);
        //    await _context.SaveChangesAsync();
        //}
       public IEnumerable<ContactUs> GetAll() => _context.ContactUs.ToList();

       


        //public Advertise GetById(int id) =>
        //    _context.Advertise.Where(x => x.id == id).FirstOrDefault();

        //public async Task UpdateAsync(Advertise obj)
        //{
        //    _context.Advertise.Update(obj);
        //    await _context.SaveChangesAsync();
        //}



    }
}
