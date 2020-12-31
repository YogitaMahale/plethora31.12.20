using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace plathora.Entity
{
  public  class SectorRegistration
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string img { get; set; }
        public string photo { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
