using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class ProductDtos
    {
        public int id { get; set; }

        //[Required]
        //[Display(Name = "Select Sector")]
       
         
        public int businessid { get; set; }

       
        public string productName { get; set; }

        public string  img { get; set; }

        public Boolean isdeleted { get; set; }

        public Boolean isactive { get; set; }
    }
}
