using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AffilatePackageIndexModel
    {
        public int id { get; set; }
        
        public int membershipid { get; set; }
        public Membership Membership { get; set; }

        
        public int commissionid { get; set; }
        public commission commission { get; set; }

         
         
        public decimal amount { get; set; }

        public decimal gst { get; set; }



        public decimal affilateamt { get; set; }     
        public decimal plethoraamt { get; set; }

        public string Description { get; set; }


        
    }
}
