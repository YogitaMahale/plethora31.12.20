using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class TalukaCreateViewmodel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required]
        [Display(Name = "Select State")]
        public int stateid { get; set; }


        [Required]
        [Display(Name = "Select City")]
        public int cityid { get; set; }

        [Required]
        public string talukaname { get; set; }

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
 