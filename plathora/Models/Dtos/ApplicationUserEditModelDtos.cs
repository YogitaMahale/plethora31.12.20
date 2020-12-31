using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class ApplicationUserEditModelDtos
    {
       public string  id { get; set; }
        public string usertype { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string profilephoto { get; set; }
        public string mobileno1 { get; set; }
        public string mobileno2 { get; set; }
        public string emailid1 { get; set; }
       public string emailid2 { get; set; }
        public string adharcardno { get; set; }
        public string adharcardphoto { get; set; }

        public string pancardno { get; set; }
        public string pancardphoto { get; set; }
       // public string password { get; set; }
        public string gender { get; set; }
        public DateTime DOB { get; set; } = DateTime.UtcNow;
       // public DateTime createddate { get; set; } = DateTime.UtcNow;
        public string house { get; set; }
        public string landmark { get; set; }
        public string street { get; set; }

        public int cityid { get; set; }
        public string zipcode { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }

  

        // public string companyName { get; set; }
        // public string designation { get; set; }
        // public string gstno { get; set; }
        // public string Website { get; set; }




        //--------bank info---
        public string bankname { get; set; }
        public string accountname { get; set; }
        public string accountno { get; set; }
        public string ifsccode { get; set; }
        public string branch { get; set; }
        public string passbookphoto { get; set; }
       // public int? Membershipid { get; set; }
     //   public string amount { get; set; }
    //    public string registerbyAffilateID { get; set; }
        public string deviceid { get; set; }
        public string password { get; set; }
    }
}


