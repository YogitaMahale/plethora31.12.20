using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
   public class BusinessRegistration
    {
        public int id { get; set; }



        public int sectorid { get; set; }

        [Required]
        public string name { get; set; }

        public string img { get; set; }
        public string photo { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

        [ForeignKey("sectorid")]
        public virtual SectorRegistration SectorRegistration { get; set; }
    }
}
