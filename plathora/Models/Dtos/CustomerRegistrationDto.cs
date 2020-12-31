using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace plathora.Models.Dtos
{
    public class CustomerRegistrationDto
    {
        public int id { get; set; }
      
        public string name { get; set; }
        public string profilephoto { get; set; }
        public string address { get; set; }

        public string mobileno1 { get; set; }

        public string mobileno2 { get; set; }
        public string emailid1 { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        //   
        public string password { get; set; }
        public string gender { get; set; }
        //public DateTime DOB { get; set; } = DateTime.UtcNow;
        //public DateTime createddate { get; set; } = DateTime.UtcNow;


        //public Boolean isdeleted { get; set; } 
        
        //public Boolean isactive { get; set; }
    }
}
