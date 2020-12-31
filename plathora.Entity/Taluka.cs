using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace plathora.Entity
{
    public class Taluka
    {
        public int id { get; set; }
        [ForeignKey("CityRegistration")]
        public int cityid { get; set; }
        public CityRegistration CityRegistration { get; set; }

        [Required]
        public string talukaname { get; set; }


        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }

    }
}
