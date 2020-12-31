using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace plathora.Entity
{
   public  class News
    {
        public int id { get; set; }
        [Required]
        public string title { get; set; }
        public string img { get; set; }
        public string description { get; set; }
        public DateTime date1 { get; set; }
        public DateTime createddate { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
