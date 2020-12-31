using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class advertiseDetailsDtos
    {

        public int id { get; set; }
      
        public int customerid { get; set; }
        
         
        public int? agentid { get; set; }
         
        public int adviceid { get; set; }
         
        public DateTime startdate { get; set; }

        
        public string title { get; set; }

        public string url { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }


        public string img1 { get; set; }
        public string img2 { get; set; }

         

        //public int? affilateid { get; set; }
        //public int customerId { get; set; }
        //public int Advertiseid { get; set; }


        //public DateTime startdate { get; set; } = DateTime.UtcNow;
        //public string title { get; set; }
        //public string videourl { get; set; }

        //public string shortdesc { get; set; }
        //public string longdesc { get; set; }
        //public string img1 { get; set; }
        //public string img2 { get; set; }


    }
}
