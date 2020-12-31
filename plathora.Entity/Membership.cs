using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace plathora.Entity
{
   public class Membership
    {
        public int id { get; set; }
        [Required]
        public string membershipName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal gst { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }

        
        public string period { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
        
    }
}
