﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class CityEditViewModel
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Select Country")]
        public int countryid { get; set; }

        [Required]
        [Display(Name = "Select Country")]
        public int stateid { get; set; }

        [Required]
        public string cityName { get; set; }



        
    }
}
