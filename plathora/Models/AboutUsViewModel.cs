using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace plathora.Models
{
    public class AboutUsViewModel
    {
        public int id { get; set; }
        [Display(Name = "Purpose of the Company")]
        public string PurposeoftheCompany { get; set; }
        [Display(Name = "About us")]
        public string AboutUsText { get; set; }
        [Display(Name = "Image")]
        public IFormFile img { get; set; }
        public string  imgpath { get; set; }
    }
}
