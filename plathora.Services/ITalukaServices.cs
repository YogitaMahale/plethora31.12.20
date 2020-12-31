using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace plathora.Services
{
   public  interface ITalukaServices
    {
        Task CreateAsync(Taluka obj);
        Taluka  GetById(int id);
        Task UpdateAsync(Taluka obj);
        Task Delete(int id);

        IEnumerable<Taluka> GetAll();
    }
}
