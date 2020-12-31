using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
 public    interface ICityRegistrationservices
    {
        Task CreateAsync(CityRegistration  obj);
        CityRegistration GetById(int affilateid);
        Task UpdateAsync(CityRegistration obj);
        Task Delete(int countryid);
        IEnumerable<SelectListItem> GetAllCity(int stateid);
        IEnumerable<SelectListItem> GetAllCities();
        IEnumerable<CityRegistration> GetAll();
    }
}
