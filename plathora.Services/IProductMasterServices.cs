using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public   interface IProductMasterServices
    {
        Task CreateAsync(ProductMaster obj);
        ProductMaster GetById(int productid);
        Task UpdateAsync(ProductMaster obj);
        Task Delete(int productid);
        IEnumerable<SelectListItem> GetAllProuct_SelectListItem(int businessid);
        IEnumerable<ProductMaster> GetAll();
         
    }
}
