using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace plathora.Models
{
    public class BankRegistrationCreateViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Bank Name")]
        public string name { get; set; }


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
