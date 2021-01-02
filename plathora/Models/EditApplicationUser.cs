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
        [Display(Name = "Adharcard No")]
        public string adharcardno { get; set; }
       
        public string adharcardphoto1 { get; set; }
        [Display(Name = "Adharcard Photo")]
        public IFormFile adharcardphoto { get; set; }
         [Display(Name = "Adharcard Photo")]
        public string pancardno { get; set; }
        public string pancardphoto1 { get; set; }

        [Display(Name = "Pancard Photo")]
        public IFormFile pancardphoto { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }





        //-------- address info
        [Display(Name = "House")]
        public string house { get; set; }
        [Display(Name = "Landmark")]
        public string landmark { get; set; }
        [Display(Name = "Street")]
        public string street { get; set; }

        [Required]
         
        [Display(Name = "Country")]
        public int countryid { get; set; }
        [Required]
        [Display(Name = "State")]
        public int stateid { get; set; }
        [Required]
        [Display(Name = "City")]
        public int? cityid { get; set; }



        [Display(Name = "Zipcode")]
        public string zipcode { get; set; }
        //public string latitude { get; set; }
        //public string longitude { get; set; }

        //--------company info---
        //public string companyName { get; set; }
        //public string designation { get; set; }
        //public string gstno { get; set; }
        //public string Website { get; set; }
        //--------bank info---
        [Display(Name = "Bank Name")]
        public string bankname { get; set; }
        [Display(Name = "Account Name")]
        public string accountname { get; set; }
        [Display(Name = "Account No")]
        public string accountno { get; set; }
        [Display(Name = "IFSC Code")]
        public string ifsccode { get; set; }
        [Display(Name = "Branch")]
        public string branch { get; set; }
        [Display(Name = "Passbook Photo")]
        public IFormFile passbookphoto { get; set; }
        public string  passbookphoto1 { get; set; }
        ////----affliate membership

        //public int? Membershipid { get; set; }

        //public string amount { get; set; }
        public string rolename { get; set; }


    }
}





