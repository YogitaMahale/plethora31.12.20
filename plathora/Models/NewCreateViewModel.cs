using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace plathora.Models
{
    public class NewCreateViewModel
    {
        public int id { get; set; }
       [Display(Name ="Title")]
        public string title { get; set; }
        [Display(Name = "Select Image")]
        public IFormFile img { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
        public Boolean isdeleted { get; set; }
        public Boolean isactive { get; set; }
        [Display(Name = "Select Date")]
        public DateTime date1 { get; set; } = DateTime.Now;
        public DateTime createddate { get; set; }
    }
}
