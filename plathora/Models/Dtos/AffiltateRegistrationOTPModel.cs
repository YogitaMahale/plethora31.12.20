using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class AffiltateRegistrationOTPModel
    {
        public int? id { get; set; }
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
        public string otpno { get; set; }       
       
      
      //--------------------
        public DateTime DOB { get; set; }
        public DateTime createddate { get; set; }

    
        public Boolean isdeleted { get; set; }
      
        public Boolean isactive { get; set; }

        //-------- address info
        public string house { get; set; }
        public string landmark { get; set; }
        public string street { get; set; }

     
        public int cityid { get; set; }
         
        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        //--------company info---
        public string companyName { get; set; }
        public string designation { get; set; }
        public string gstno { get; set; }
        public string Website { get; set; }
        //--------bank info---
        public string bankname { get; set; }
        public string accountname { get; set; }
        public string accountno { get; set; }
        public string ifsccode { get; set; }
        public string branch { get; set; }
        public string passbookphoto { get; set; }
        //----affliate membership
       
        public int Membershipid { get; set; }
        

        public string amount { get; set; }

        public int registerbyAffilateID { get; set; }
        public string deviceid { get; set; }



    }
}
