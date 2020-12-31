using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace plathora.Services.Implementation
{
 public   class ProductMasterServices :IProductMasterServices
    {
        private readonly ApplicationDbContext _context;
        public ProductMasterServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(ProductMaster obj)
        {
            await _context.ProductMaster.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = GetById(id);
            state.isdeleted = true;
            _context.ProductMaster.Update(state);
            await _context.SaveChangesAsync();
        }
       
        public IEnumerable<ProductMaster> GetAll() => _context.ProductMaster.Where(x => x.isdeleted == false).ToList();
        
        public ProductMaster GetById(int id) =>
            _context.ProductMaster.Where(x => x.id == id).FirstOrDefault();


        public async Task UpdateAsync(ProductMaster  obj)
        {
            _context.ProductMaster.Update(obj);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<SelectListItem> GetAllProuct_SelectListItem(int businessid)
        {
            return GetAll().Where(x => x.businessid == businessid).Select(emp => new SelectListItem()
            {
                Text = emp.productName ,
                Value = emp.id.ToString()
            });
        }
    }
}
