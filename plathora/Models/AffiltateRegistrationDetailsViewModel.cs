using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AffiltateRegistrationDetailsViewModel
    {
        public int id { get; set; }
       
        public string name { get; set; }

        public string profilephoto { get; set; }
       
        public string mobileno1 { get; set; }
        public string mobileno2 { get; set; }
        public string emailid1 { get; set; }
        public string emailid2 { get; set; }
        public string adharcardno { get; set; }
        public string adharcardphoto { get; set; }

        public string pancardno { get; set; }
        public string pancardphoto { get; set; }
       
        public string password { get; set; }
       
        public string gender { get; set; }

        public DateTime DOB { get; set; }

        public DateTime createddate { get; set; }
    }
}
