using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public   interface Iratingsservices
    {
        Task<int> CreateAsync(rating obj);
        rating GetById(int id);
        Task UpdateAsync(rating obj);
        Task Delete(int id);

        IEnumerable<rating> GetAll();
    }
}
