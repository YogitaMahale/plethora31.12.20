using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace plathora.Entity
{
 public  class commission
    {
        public int id { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal commissionper { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
