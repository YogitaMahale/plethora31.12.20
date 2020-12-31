using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public  interface IcommissionServices
    {
        Task CreateAsync(commission  obj);
        commission GetById(int id);
        Task UpdateAsync(commission obj);
        Task Delete(int id);

        IEnumerable<commission> GetAll();
    }
}
