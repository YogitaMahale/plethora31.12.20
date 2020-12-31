using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class search_BusinessRegistrationIndexViewModel
    {
        public int id { get; set; }



        public int sectorid { get; set; }

        public string name { get; set; }
        public string type { get; set; }
        public string img { get; set; }
        public virtual SectorRegistration SectorRegistration { get; set; }
    }
}
