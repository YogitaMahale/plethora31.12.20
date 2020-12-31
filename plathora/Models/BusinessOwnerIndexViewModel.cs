using plathora.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BusinessOwnerIndexViewModel
    {
        public int id { get; set; }
        
        public string name { get; set; }

        public string profilephoto { get; set; }
         
        public string mobileno1 { get; set; }
        
        public DateTime DOB { get; set; }

        public DateTime createddate { get; set; }

        

    }
}
