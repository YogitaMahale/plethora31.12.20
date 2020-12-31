using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using plathora.Entity;
using plathora.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace plathora.Services
{
  public   interface IMembershipServices
    {
        Task CreateAsync(Membership obj);
        Membership GetById(int id);
        Task UpdateAsync(Membership obj);
        Task Delete(int id);

        IEnumerable<Membership> GetAll();
     //  IEnumerable<SelectListItem> GetAllCountry();
    }
}
