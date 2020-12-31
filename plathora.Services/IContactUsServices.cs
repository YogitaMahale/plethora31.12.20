using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using plathora.Entity;
namespace plathora.Services
{
    public interface IContactUsServices
    {
        Task<int> CreateAsync(ContactUs obj);
        //advertisementInfo GetById(int id);
        //Task UpdateAsync(advertisementInfo obj);
        //Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
       IEnumerable<ContactUs> GetAll();
    }
}
