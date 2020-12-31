using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public  interface IsliderServices
    {
        Task CreateAsync(slider  obj);
        slider GetById(int id);
        Task UpdateAsync(slider obj);
        Task Delete(int id);
         
        IEnumerable<slider> GetAll();
    }
}
