using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class getSocialInfoDtos
    {
        public int id { get; set; }

        
        public string  customerid { get; set; }
        public string customerName { get; set; }



        public string img { get; set; }
        public string description { get; set; }


        public int likestatus { get; set; }
        public Boolean isdeleted { get; set; }
         
        public Boolean isactive { get; set; }
        public int likecount { get; set; }
        public int commentcount { get; set; }

    }
}
