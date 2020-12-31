using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BusinessRegistrationEditViewModel
    {
        public int id { get; set; }

        [Required]

        public int sectorid { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required"), StringLength(500, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s]+$")]

        public string name { get; set; }
        [Display(Name = "Icon")]
        public IFormFile img { get; set; }
        public string img1 { get; set; }
        [Display(Name = "Image")]
        public IFormFile photo { get; set; }
        public string photo1 { get; set; }
    }
}
