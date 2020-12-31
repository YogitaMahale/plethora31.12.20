using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
  public  class tblfeedback
    {
        public int id { get; set; }
        
        public string  title { get; set; }
        public string desc { get; set; }
        public string img { get; set; }

       
        public int customerid { get; set; }
        

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
      
    }
}
