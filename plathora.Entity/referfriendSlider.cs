using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace plathora.Entity
{
  public class referfriendSlider
    {
        public int id { get; set; }
        public string name { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
