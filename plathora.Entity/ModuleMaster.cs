using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public   class ModuleMaster
    {
        public int id { get; set; }
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal amount { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
