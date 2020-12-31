using plathora.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public interface IVideoServices
    {
        Task CreateAsync(Videos obj);
        Videos GetById(int id);
        Task UpdateAsync(Videos obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<Videos> GetAll();


    }
}