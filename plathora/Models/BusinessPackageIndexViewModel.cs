using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BusinessPackageIndexViewModel
    {
        public int id { get; set; }



        public int pkgId { get; set; }

    
        public decimal Amount { get; set; }
       
        public string description { get; set; }
        
        public string period { get; set; }

        public decimal gst { get; set; }

        public decimal affilateamt { get; set; }
        
        public decimal plethoraamt { get; set; }


        public virtual PackageRegistration PackageRegistration { get; set; }
    }
}
