using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public   interface ICountryRegistrationservices
    {
        Task CreateAsync(CountryRegistration obj);
        CountryRegistration GetById(int affilateid);
        Task UpdateAsync(CountryRegistration obj);
        Task Delete(int countryid);

        IEnumerable<CountryRegistration> GetAll();
        IEnumerable<SelectListItem> GetAllCountry();
    }
}
