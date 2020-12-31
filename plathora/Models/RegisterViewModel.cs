using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace plathora.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

      

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Mobile No.")]
        public string mobileno1 { get; set; }
    }
}
