using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class SocialDetailsbySocialIdDtos
    {
        public int id { get; set; }

       
        public int customerid { get; set; }
       
        public string img { get; set; }
        public string description { get; set; }


        public int likecount { get; set; }
        public int commentcount { get; set; }
    }
}
