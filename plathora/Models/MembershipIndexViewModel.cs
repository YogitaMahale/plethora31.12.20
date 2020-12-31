using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class MembershipIndexViewModel
    {
        public int id { get; set; }
        
        public string membershipName { get; set; }

        public decimal  gst { get; set; }
        public decimal amount { get; set; }


        public string period { get; set; }
    }
}
