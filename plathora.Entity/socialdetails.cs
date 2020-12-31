using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
 public   class socialdetails
    {
        public int id { get; set; }

        
        public int socialid { get; set; }



        //  public int customerid { get; set; }

        [ForeignKey("ApplicationUser")]
        public string customerid { get; set; }



        public int LikeCnt { get; set; } = 0;
        
        public string comment { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
         
    }
}
