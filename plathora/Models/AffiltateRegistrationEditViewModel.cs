using Microsoft.AspNetCore.Http;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class AffiltateRegistrationEditViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Name is Required"), StringLength(500, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]+$"), Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Profile Photo")]
        public IFormFile profilephoto { get; set; }
        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Mobile No is Required")]
        public string mobileno1 { get; set; }
        [Display(Name = "Alternet Mobile No.")]
        public string mobileno2 { get; set; }
        [Display(Name = "Email ID")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string emailid1 { get; set; }
        [Display(Name = "Alternet Email ID")]
        public string emailid2 { get; set; }
        [Display(Name = "Adharcard No")]
        public string adharcardno { get; set; }
        [Display(Name = "Adharcard Photo")]
        public IFormFile adharcardphoto { get; set; }
        [Display(Name = "Pancard No")]
        public string pancardno { get; set; }
        [Display(Name = "Pancard No")]
        public IFormFile pancardphoto { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Required]

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [DataType(DataType.Date), Display(Name = "Date of Borth")]
        public DateTime DOB { get; set; } = DateTime.UtcNow;
      
       

        //--------
        [Display(Name = "House/Block/Building")]
        public string house { get; set; }
        [Display(Name = "LandMark")]
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
        public int cityid { get; set; }
        public CityRegistration CityRegistration { get; set; }
        [Display(Name = "Select Zipcode")]
        public string zipcode { get; set; }
        [Display(Name = "Latitude")]
        public string latitude { get; set; }
        [Display(Name = "Longitude")]
        public string longitude { get; set; }

        //-----------
        [Display(Name = "CompanyName")]
        public string companyName { get; set; }
        [Display(Name = "Designation")]
        public string designation { get; set; }
        [Display(Name = "GST No.")]
        public string gstno { get; set; }
        [Display(Name = "Website")]
        public string Website { get; set; }
        [Display(Name = "Bank Name")]
        //--------bank info---
        public string bankname { get; set; }
        [Display(Name = "Account Name")]
        public string accountname { get; set; }
        [Display(Name = "Account No")]
        public string accountno { get; set; }
        [Display(Name = "IFSC code")]
        public string ifsccode { get; set; }
        [Display(Name = "Branch")]
        public string branch { get; set; }
        [Display(Name = "Passbook")]
        public IFormFile passbookphoto { get; set; }
        //----affliate membership
        [Required]
        [Display(Name = "Membership")]
        public int Membershipid { get; set; }
        public Membership Membership { get; set; }
        [Display(Name = "Amount")]
        public string amount { get; set; }
        public int registerbyAffilateID { get; set; }
    }
}
