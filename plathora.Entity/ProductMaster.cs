using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
    public class ProductMaster
    {
        public int id { get; set; }
        [ForeignKey("BusinessRegistration")]
        public int businessid { get; set; }
        public BusinessRegistration BusinessRegistration { get; set; }

        [Required]
        public string productName { get; set; }
        public string img { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }


    }
}
