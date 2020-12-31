using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class selectallBusinessDetailsDtos
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string profilephoto { get; set; }
        public string PhoneNumber { get; set; }
        public string mobileno2 { get; set; }
       
        public int rating { get; set; }
        public string cityname { get; set; }
        public string businesstime { get; set; }
        public string Email { get; set; }

    }
}
