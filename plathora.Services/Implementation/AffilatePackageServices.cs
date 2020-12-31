using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace plathora.Services.Implementation
{
 public   class AffilatePackageServices:IAffilatePackageServices
    {
        private readonly ApplicationDbContext _context;
        public AffilatePackageServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(AffilatePackage obj)
        {
            await _context.AffilatePackage.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = getbyid(id);
            state.isdeleted = true;
            _context.AffilatePackage.Update(state);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<AffilatePackage> GetAll() => _context.AffilatePackage.Where(x => x.isdeleted == false).ToList();
        public AffilatePackage getbyid(int id) =>
            _context.AffilatePackage.Where(x => x.id == id).FirstOrDefault();

        public AffilatePackage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AffilatePackage obj)
        {
            _context.AffilatePackage.Update(obj);
            await _context.SaveChangesAsync();
        }
        //public IEnumerable<SelectListItem> GetAllCity(int stateid)
        //{
        //    return GetAll().Where(x => x.stateid == stateid).Select(emp => new SelectListItem()
        //    {
        //        Text = emp.cityName,
        //        Value = emp.id.ToString()
        //    });
        //}
    }
}
