using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Persistence;

namespace plathora.Services
{
   public  interface IBankRegistrationServices
    {
        Task CreateAsync(BankRegistration obj);
        BankRegistration GetById(int bankid);
        Task UpdateAsync(BankRegistration obj);
        Task Delete(int bankid);

        IEnumerable<BankRegistration> GetAll();
        IEnumerable<SelectListItem> GetAllBank();
    }
}
