using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AdvertiseIndexViewModel
    {
        public int id { get; set; }

        public string name { get; set; }
        public decimal gst { get; set; }

        public string img { get; set; }
        public decimal Amount { get; set; }
        
        public string description { get; set; }


        public decimal affilateamt { get; set; }
         
        public decimal plethoraamt { get; set; }


        public int period { get; set; }

 
    }
}
