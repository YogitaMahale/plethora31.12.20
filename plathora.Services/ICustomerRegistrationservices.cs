using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using plathora.Entity;
using plathora.Persistence;
namespace plathora.Services
{
   public  interface ICustomerRegistrationservices
    {
        Task<int> CreateAsync(CustomerRegistration obj);
       // Task CreateAsync(CustomerRegistration obj);
        CustomerRegistration GetById(int customerid);
        Task UpdateAsync(CustomerRegistration obj);
        void  Updatestatus(CustomerRegistration obj);
        Task Delete(int customerid);
         
        IEnumerable<CustomerRegistration> GetAll();
    }
}
