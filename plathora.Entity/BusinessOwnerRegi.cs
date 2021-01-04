using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public  class BusinessOwnerRegi
    {
 

        public int id { get; set; }  

        [ForeignKey("ApplicationUser")]
        public string customerid { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
       
       
        public string description { get; set; }
        public string Regcertificate { get; set; }
        public string businessid { get; set; }
        // public string productid { get; set; }
       // [ForeignKey("ProductMaster")]
        public string productid { get; set; }
      //  public ProductMaster ProductMaster { get; set; }
        public string lic { get; set; }     

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


        public string facebookLink { get; set; }
        public string twitterLink { get; set; }
        public string youtubeLink { get; set; }
        public string linkedinLink { get; set; }
        public string googleplusLink { get; set; }
        public string instagramLink { get; set; }
        //paymnet details----------------------------------
        public DateTime Registrationdate { get; set; } = DateTime.Now;
        public DateTime Expirydate { get; set; }
        public string PaymentStatus { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }


        [ForeignKey("BusinessPackage")]
        public int? BusinessPackageId { get; set; } = null;
        public BusinessPackage BusinessPackage { get; set; }



        //[ForeignKey("Membership")]
        //public int? MembershipId { get; set; } = null;
        //public Membership Membership { get; set; }

        //-------- address info
        public string house { get; set; }
        public string landmark { get; set; }
        public string street { get; set; }

        [ForeignKey("CityRegistration")]
        public int? cityid { get; set; }
        public CityRegistration CityRegistration { get; set; }




        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        //--------company info---
        public string companyName { get; set; }
         
        public string gstno { get; set; }
        public string Website { get; set; }

        public string businessOperation { get; set; }
        public string businessType { get; set; }

        public string registerbyAffilateUniqueId { get; set; }
        public string organization { get; set; }
        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
    }
}

