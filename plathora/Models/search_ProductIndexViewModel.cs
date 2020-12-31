using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class search_ProductIndexViewModel
    {
        public int id { get; set; }
        public int sectorid { get; set; }
        public int businessid { get; set; }
        public BusinessRegistration BusinessRegistration { get; set; }

        public SectorRegistration SectorRegistration { get; set; }
        public string productName { get; set; }

        public string type { get; set; }
        public string img { get; set; }

    }
}
