using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public class ApplicationUser: IdentityUser
    {  

        

        [Required]
        public string name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string profilephoto { get; set; }

        public string mobileno2 { get; set; }

        public string emailid2 { get; set; }
        public string adharcardno { get; set; }
        public string adharcardphoto { get; set; }

        public string pancardno { get; set; }
        public string pancardphoto { get; set; }
       
        [Required]
        public string gender { get; set; }

        public DateTime DOB { get; set; }


        public DateTime createddate { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }


        ////-------- address info


        public string house { get; set; }
       public string landmark { get; set; }
        public string street { get; set; }

        [ForeignKey("CityRegistration")]
        public int? cityid { get; set; }
        public CityRegistration CityRegistration { get; set; }

         


        public string zipcode { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        ////--------company info---
        //public string companyName { get; set; }
        //public string designation { get; set; }
        //public string gstno { get; set; }
        //public string Website { get; set; }
        ////--------bank info---
        public string bankname { get; set; }
        public string accountname { get; set; }
        public string accountno { get; set; }
        public string ifsccode { get; set; }
        public string branch { get; set; }
        public string passbookphoto { get; set; }
        //----affliate membership
        //[ForeignKey("Membership")]
        //public int? Membershipid { get; set; } = null;
        //public Membership Membership { get; set; }


        
        public string registerbyAffilateID { get; set; }
        
      //  public string amount { get; set; }

      
        public string deviceid { get; set; }
        [NotMapped]
        public string Role { get; set; }

        //paymnet details
        [ForeignKey("AffilatePackage")]
        public int? AffilatePackageid { get; set; } = null;
        public AffilatePackage AffilatePackage { get; set; }

        public string PaymentStatus { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }
        public string uniqueId { get; set; }

        public bool loginStatus { get; set; } = false;
        public DateTime logintime { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal commissionAmount { get; set; } = 0;

    }
}
