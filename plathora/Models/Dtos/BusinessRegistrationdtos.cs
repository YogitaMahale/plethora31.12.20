using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class BusinessRegistrationdtos
    {
        public int id { get; set; }



        public int sectorid { get; set; }

        
        public string name { get; set; }

        public string img { get; set; }


       
        public Boolean isdeleted { get; set; }
      
        public Boolean isactive { get; set; }

        
    }
}
