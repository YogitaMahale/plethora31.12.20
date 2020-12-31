using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class VideoEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Select Module")]
        public int fkmoduleid { get; set; }
        [Display(Name = "Type")]

        public string type { get; set; }
        [Display(Name = "Video Name")]
        public string videoName { get; set; }
        [Display(Name = "Link")]
        public string videoLink { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }


        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
