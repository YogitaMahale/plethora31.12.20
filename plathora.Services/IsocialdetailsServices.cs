using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public  interface IsocialdetailsServices
    {
        Task<int> CreateAsync(socialdetails obj);
        socialdetails GetById(int id);
        Task UpdateAsync(socialdetails obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<socialdetails> GetAll();
    }
}
