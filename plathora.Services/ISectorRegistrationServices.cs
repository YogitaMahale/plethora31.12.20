using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Persistence;
namespace plathora.Services
{
  public   interface ISectorRegistrationServices
    {
        Task CreateAsync(SectorRegistration obj);
        SectorRegistration GetById(int sectorid);
        Task UpdateAsync(SectorRegistration obj);
        Task Delete(int sectorid);

        IEnumerable<SectorRegistration> GetAll();
        IEnumerable<SelectListItem> GetAllsector();
    }
}
