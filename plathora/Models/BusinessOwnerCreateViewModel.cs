using Microsoft.AspNetCore.Http;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BusinessOwnerCreateViewModel
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
        public string emailid1 { get; set; }
        [Display(Name = "Alternet Email ID")]
        public string emailid2 { get; set; }
        [Display(Name = "AdharCard No.")]
        public string adharcardno { get; set; }
        [Display(Name = "Adharcard Photo.")]
        public IFormFile adharcardphoto { get; set; }
        [Display(Name = "PanCard No.")]
        public string pancardno { get; set; }
        [Display(Name = "Pancard Photo.")]
        public IFormFile pancardphoto { get; set; }
       
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }
        [Display(Name = "Select Gender")]
        public string gender { get; set; }
        [Display(Name = "Pin No.")]
        public string pinno { get; set; }
        [DataType(DataType.Date), Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date), Display(Name = "Registration Date")]
        public DateTime createddate { get; set; } = DateTime.UtcNow;

       
        public Boolean isdeleted { get; set; }
       
        public Boolean isactive { get; set; }


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
         
        public string latitude { get; set; }
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
        [Display(Name = "Description")]
        public string Discription { get; set; }
        [Display(Name = "Reg. certificate")]
        public string Regcertificate { get; set; }
        [Required]
        [Display(Name = "Sector")]
        public int sectorid { get; set; }
        [Required]
        [Display(Name = "Business")]
        public int businessid { get; set; }
        [Required]
        [Display(Name = "Product")]
        public int productid { get; set; }
        public ProductMaster ProductMaster { get; set; }
        public string lic { get; set; }
    }
}
