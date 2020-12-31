using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
   public interface IdistanceServices
    {
        //Task CreateAsync(CityRegistration obj);
        distance GetById(int id);
        //Task UpdateAsync(CityRegistration obj);
        //Task Delete(int countryid);
        //IEnumerable<SelectListItem> GetAllCity(int stateid);
        //IEnumerable<CityRegistration> GetAll();
    }
}
