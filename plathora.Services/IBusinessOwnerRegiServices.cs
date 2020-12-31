using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
   public interface IBusinessOwnerRegiServices
    {
        //Task CreateAsync(BusinessOwnerRegi obj);
        Task<int> CreateAsync(BusinessOwnerRegi obj);
        BusinessOwnerRegi GetById(int id);
        Task UpdateAsync(BusinessOwnerRegi obj);
        Task Delete(int id);

        IEnumerable<BusinessOwnerRegi> GetAll();
    }
}
