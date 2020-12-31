using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class Moduledetails
    {
        public int id { get; set; }
        
        public string Name { get; set; }
         
        public decimal amount { get; set; }        
        public Boolean isactive { get; set; }

        public IEnumerable<Videos> videodetails { get; set; }
    }
}
