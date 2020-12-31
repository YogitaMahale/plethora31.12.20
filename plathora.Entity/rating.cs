using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace plathora.Entity
{
  public   class rating
    {
        public int id { get; set; }

        public int? customerid { get; set; }
        public int? affilateid { get; set; }       
      
        public string ratingg { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
