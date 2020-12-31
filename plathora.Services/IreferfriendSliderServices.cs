using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
  public  interface IreferfriendSliderServices
    {
        Task CreateAsync(referfriendSlider obj);
        referfriendSlider GetById(int id);
        Task UpdateAsync(referfriendSlider obj);
        Task Delete(int id);
         
        IEnumerable<referfriendSlider> GetAll();
    }
}
