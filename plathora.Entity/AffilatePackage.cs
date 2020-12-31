using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public  class AffilatePackage
    {
        public int id { get; set; }
        [ForeignKey("Membership")]
        public int membershipid { get; set; }
        public Membership Membership { get; set; }

        [ForeignKey("commission")]
        public int commissionid { get; set; }
        public commission commission { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }

        
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal gst { get; set; }


        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal affilateamt { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal plethoraamt { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
