using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public interface IAdvertiseServices
    {
        Task CreateAsync(Advertise  obj);
        Advertise GetById(int id);
        Task UpdateAsync(Advertise obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<Advertise> GetAll();
    }
}
