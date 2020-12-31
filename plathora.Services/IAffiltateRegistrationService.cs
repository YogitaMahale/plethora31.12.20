 
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
   public  interface IAffiltateRegistrationService
    {
        //Task CreateAsync(AffiltateRegistration obj);
        Task<int> CreateAsync(AffiltateRegistration obj);
        AffiltateRegistration GetById(int affilateid);
        Task UpdateAsync(AffiltateRegistration obj);
        Task Delete(int affilateid);

        IEnumerable<AffiltateRegistration> GetAll();
    }
}
