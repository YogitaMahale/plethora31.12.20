using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class ContactUsViewModel
    {


        public int id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Mobile No.")]
        public string Mobileno { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }

    }
}
