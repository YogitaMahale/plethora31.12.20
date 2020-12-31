using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BankRegistrationEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Sector Name")]
        public string name { get; set; }

    }
}
