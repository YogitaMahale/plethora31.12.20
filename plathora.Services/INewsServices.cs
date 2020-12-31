using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Persistence;
namespace plathora.Services
{
  public   interface INewsServices
    {
        Task CreateAsync(News obj);
        News GetById(int sectorid);
        Task UpdateAsync(News obj);
        Task Delete(int sectorid);

        IEnumerable<News> GetAll();
         
    }
}
