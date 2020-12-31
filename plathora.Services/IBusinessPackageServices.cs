using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
namespace plathora.Services
{
  public   interface IBusinessPackageServices
    {
        Task CreateAsync(BusinessPackage obj);
        BusinessPackage GetById(int businssid);
        Task UpdateAsync(BusinessPackage obj);
        Task Delete(int countryid);
       // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<BusinessPackage> GetAll();
    }
}
