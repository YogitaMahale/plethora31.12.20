using plathora.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class SectorRegistrationViewModeldtos
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string img { get; set; }

       // public List<BusinessRegistration> businessRegistration { get; set; }

             public List<BusinessRegistrationdtos> businessRegistrationdtos { get; set; }

        [DefaultValue("false")]
        public Boolean isdeleted { get; set; }
        [DefaultValue("false")]
        public Boolean isactive { get; set; }
    }
}
