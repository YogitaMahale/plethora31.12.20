using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class search_BusinessOwnerRegistrationDtos
    {
        public string id { get; set; }
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
       // public string password { get; set; }
        public string gender { get; set; }
       // public string pinno { get; set; }
        public DateTime DOB { get; set; } = DateTime.UtcNow;
        // public DateTime createddate { get; set; } = DateTime.UtcNow;


        //  public Boolean isdeleted { get; set; }

        // public Boolean isactive { get; set; }
        public string house { get; set; }
        public string landmark { get; set; }
        public string street { get; set; }
        //public int countryid { get; set; }
        //public int stateid { get; set; }
        public string cityid { get; set; }
        public string zipcode { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
        public string companyName { get; set; }
        public string designation { get; set; }
        public string gstno { get; set; }
        public string Website { get; set; }
        //public string Discription { get; set; }
        public string Regcertificate { get; set; }

        //public int sectorid { get; set; }
        public string businessid { get; set; }




        public string productid { get; set; }
        public string lic { get; set; }
        public string  registerbyAffilateID { get; set; }
        public string deviceid { get; set; }
        public int? customerid { get; set; }

        public string sliderimg1 { get; set; }
        public string sliderimg2 { get; set; }
        public string sliderimg3 { get; set; }
        public string sliderimg4 { get; set; }
        public string sliderimg5 { get; set; }
        public string type { get; set; }
    }
}
