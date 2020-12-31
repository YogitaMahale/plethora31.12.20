using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class sliderCreateViewModel
    {
        public int id { get; set; }
        [Display(Name ="Selet Image")]
        public IFormFile  name { get; set; }


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
