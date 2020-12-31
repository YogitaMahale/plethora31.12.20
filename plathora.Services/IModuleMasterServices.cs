using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
namespace plathora.Services
{
   public  interface IModuleMasterServices
    {
        Task CreateAsync(ModuleMaster obj);
        ModuleMaster GetById(int id);
        Task UpdateAsync(ModuleMaster obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllModule();
        IEnumerable<ModuleMaster> GetAll();
    }
}
