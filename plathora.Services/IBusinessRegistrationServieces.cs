using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
namespace plathora.Services
{
  public interface IBusinessRegistrationServieces
    {
        Task CreateAsync(BusinessRegistration obj);
        BusinessRegistration GetById(int businessid);
        Task UpdateAsync(BusinessRegistration obj);
        Task Delete(int businessid);
        IEnumerable<SelectListItem> GetAllBusiness(int sectorId);
        IEnumerable<BusinessRegistration> GetAll();
    }
}
