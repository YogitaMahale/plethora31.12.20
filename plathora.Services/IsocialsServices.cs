using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public  interface IsocialsServices
    {
        Task<int> CreateAsync(social obj);
        social GetById(int id);
        Task UpdateAsync(social obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<social> GetAll();
    }
}
