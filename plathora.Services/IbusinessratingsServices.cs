using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public  interface IbusinessratingsServices
    {
        Task<int> CreateAsync(businessrating obj);
        businessrating GetById(int id);
        Task UpdateAsync(businessrating obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<businessrating> GetAll();
    }
}
