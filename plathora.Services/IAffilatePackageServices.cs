using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
   public interface IAffilatePackageServices
    {
        Task CreateAsync(AffilatePackage obj);
        AffilatePackage getbyid(int id);
        Task UpdateAsync(AffilatePackage obj);
        Task Delete(int id);
        //ienumerable<selectlistitem> getallcity(int stateid);
        IEnumerable<AffilatePackage> GetAll();
    }
}
