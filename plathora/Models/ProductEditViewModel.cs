using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class ProductEditViewModel
    {

        public int id { get; set; }

        [Required]
        [Display(Name = "Select Sector")]
        public int sectorid { get; set; }

        [Required]
        [Display(Name = "Select Business")]
        public int businessid { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Display(Name = "Image")]
        public IFormFile img { get; set; }
        public string img1 { get; set; }

    }
}
