using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
 public    interface ItaxServices
    {
        Task CreateAsync(tax obj);
        tax GetById(int id);
        Task UpdateAsync(tax obj);
        Task Delete(int id);

        IEnumerable<tax> GetAll();
    }
}
