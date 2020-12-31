using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public   class Advertise
    {
        public int id { get; set; }
        //[ForeignKey("AffiltateRegistration")]
        //public int affilateid { get; set; }
        //public AffiltateRegistration AffiltateRegistration { get; set; }


        public string name { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int period { get; set; }

        public string img { get; set; }

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
