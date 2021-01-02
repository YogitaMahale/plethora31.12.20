using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
   public  class AboutUsServicesServices : IAboutUsServices
    {
        private readonly ApplicationDbContext _context;
        public AboutUsServicesServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //public async Task<int> CreateAsync(advertisementInfo obj)
        //{
        //    await _context.advertisementInfos.AddAsync(obj);
        //    await _context.SaveChangesAsync();
        //    return obj.id;
        //}



        //public async Task Delete(int id)
        //{
        //    var obj = GetById(id);
        //    obj.isdeleted = true;
        //    _context.advertisementInfos.Update(obj);
        //    await _context.SaveChangesAsync();
        //}
      //  public IEnumerable<advertisementInfo> GetAll() => _context.advertisementInfos.Where(x => x.isdeleted == false).ToList();



        public AboutUs GetById(int id) =>
            _context.AboutUs.Where(x => x.id == id).FirstOrDefault();

        public async Task UpdateAsync(AboutUs obj)
        {
            _context.AboutUs.Update(obj);
            await _context.SaveChangesAsync();
        }
        public string generateRandomNo(string name)
        {
            Random generator = new Random();
            int r = generator.Next(100000, 1000000);
            string uniqueId = name.ToString().ToUpper().Trim() + r;

            var userList = _context.applicationUsers.Where(x => x.uniqueId == uniqueId).ToList();
            if (userList == null || userList.Count == 0)
            {
                return uniqueId;
            }
            else
            {
                generateRandomNo(name);
            }

            return uniqueId.Trim();
        }


    }
}
