using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
   public interface ItblfeedbackServices
    {
        Task<int> CreateAsync(tblfeedback obj);
        tblfeedback GetById(int id);
        Task UpdateAsync(tblfeedback obj);
        Task Delete(int id);
        // IEnumerable<SelectListItem> GetAllState(int businssid);
        IEnumerable<tblfeedback> GetAll();
    }
}
