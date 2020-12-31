using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Models
{
  public  class BusinessOwnerRegiIndexViewModel
    {

  //      	--, password, , pinno,, isactive, 
		//--, Discription,
		
        public string  id { get; set; }
        [Required]
        public string name { get; set; }

        public string profilephoto { get; set; }
        [Required]
        public string mobileno1 { get; set; }
        public string mobileno2 { get; set; }
        public string emailid1 { get; set; }
        public string emailid2 { get; set; }
        public string adharcardno { get; set; }
        public string adharcardphoto { get; set; }

        public string pancardno { get; set; }
        public string pancardphoto { get; set; }
        //[Required]
        //public string password { get; set; }
        [Required]
        public string gender { get; set; }
       // public string pinno { get; set; }
        public DateTime DOB { get; set; }


        public DateTime createddate { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
      //  [DefaultValue("false")]
        //public Boolean isactive { get; set; }


        //--------
        public string house { get; set; }
        public string landmark { get; set; }
        public string street { get; set; }

        //[ForeignKey("CityRegistration")]
        public int cityid { get; set; }
        //public CityRegistration CityRegistration { get; set; }
        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        //-----------
        public string companyName { get; set; }
        public string designation { get; set; }
        public string gstno { get; set; }
        public string Website { get; set; }
     //   public string Discription { get; set; }
        public string Regcertificate { get; set; }
        public string businessid { get; set; }
        public string productid { get; set; }
        //[ForeignKey("ProductMaster")]
        //public int productid { get; set; }
        //public ProductMaster ProductMaster { get; set; }
        public string lic { get; set; }
        public string registerbyAffilateID { get; set; }
        public string deviceid { get; set; }


       // [ForeignKey("customerRegistration")]
        public string? customerid { get; set; }
      //  public CustomerRegistration customerRegistration { get; set; }

        public string MondayOpen { get; set; }
        public string MondayClose { get; set; }       

        public string TuesdayOpen { get; set; }
        public string TuesdayClose { get; set; }

        public string WednesdayOpen { get; set; }
        public string WednesdayClose { get; set; }

        public string ThursdayOpen { get; set; }
        public string ThursdayClose { get; set; }

        public string FridayOpen { get; set; }
        public string FridayClose { get; set; }

        public string SaturdayOpen { get; set; }
        public string SaturdayClose { get; set; }
        public string SundayOpen { get; set; }
        public string SundayClose { get; set; }

        public int CallCount { get; set; } = 0;
        public int SMSCount { get; set; } = 0;
        public int WhatssappCount { get; set; } = 0;
        public int ShareCount { get; set; } = 0;


        public string sliderimg1 { get; set; }
        public string sliderimg2 { get; set; }
        public string sliderimg3 { get; set; }
        public string sliderimg4 { get; set; }
        public string sliderimg5 { get; set; }
        public string rating { get; set; }
        public int businessSRNo { get; set; }

    }
}
