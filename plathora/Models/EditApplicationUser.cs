using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class EditApplicationUser
    {
        public string Id { get; set; }

        [Required]
        [Display(Name ="First Name")]

        public string name { get; set; }

        [Required]
        [Display(Name = "Middle Name")]

        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        


        [Display(Name = "Profile Photo")]
        public string  profilephoto1 { get; set; }
        public IFormFile profilephoto { get; set; }
        [Display(Name = "Mobile No1")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Mobile No2")]
        public string mobileno2 { get; set; }
        [Display(Name = "Email Id1")]
        public string Email { get; set; }
        [Display(Name = "Email Id2")]
        public string emailid2 { get; set; }
        
        public string adharcardno { get; set; }
        public string adharcardphoto1 { get; set; }
        public IFormFile adharcardphoto { get; set; }

        public string pancardno { get; set; }
        public string pancardphoto1 { get; set; }
        public IFormFile pancardphoto { get; set; }

        [Required]
        public string gender { get; set; }

        public DateTime DOB { get; set; }


      


        //-------- address info
        //public string house { get; set; }
        //public string landmark { get; set; }
        //public string street { get; set; }

        //[Required]
        //[Display(Name = "Country")]
        //public int countryid { get; set; }
        //[Required]
        //[Display(Name = "State")]
        //public int stateid { get; set; }
        //[Required]
        //[Display(Name = "City")]        
        //public int? cityid { get; set; }
       



        //public string zipcode { get; set; }
        //public string latitude { get; set; }
        //public string longitude { get; set; }

        //--------company info---
        //public string companyName { get; set; }
        //public string designation { get; set; }
        //public string gstno { get; set; }
        //public string Website { get; set; }
        //--------bank info---
        public string bankname { get; set; }
        public string accountname { get; set; }
        public string accountno { get; set; }
        public string ifsccode { get; set; }
        public string branch { get; set; }
        public IFormFile passbookphoto { get; set; }
        public string  passbookphoto1 { get; set; }
        ////----affliate membership

        //public int? Membershipid { get; set; }

        //public string amount { get; set; }
        public string rolename { get; set; }


    }
}





