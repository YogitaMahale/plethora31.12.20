using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace plathora.Entity
{
  public class businessrating
    {
        public int id { get; set; }

        public string CustomerId { get; set; }
        public int? BusinessOwnerId { get; set; }

        public string rating { get; set; }
        public string comment { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
      
    }
}
