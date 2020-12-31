using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
 public class Videos
    {
        public int id { get; set; }
        [Required]
        public int fkmoduleid { get; set; }
        [ForeignKey("fkmoduleid")]
        public ModuleMaster moduleMaster { get; set; }

        public string type { get; set; }
        public string videoName { get; set; }

        public string videoLink { get; set; }
        public string description { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
