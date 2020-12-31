using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public class social
    {
        public int id { get; set; }

        //[ForeignKey("CustomerRegistration")]
        //public int customerid { get; set; }
        [ForeignKey("ApplicationUser")]
        public string customerid { get; set; }
        //    public CustomerRegistration CustomerRegistration { get; set; }




        public string img { get; set; }
        public string description { get; set; }
        //public string longdesc { get; set; }


        //public int LikeCnt { get; set; } = 0;
        //public int disLikeCnt { get; set; } = 0;
        //public string comment { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
       

       
        //public virtual  CountryRegistration CountryRegistration { get; set; }

    }
}
