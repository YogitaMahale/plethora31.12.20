using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class VideoIndexViewModel
    {
        public int id { get; set; }
        
        public string modulename { get; set; }
        public int fkmoduleid { get; set; }
       

        public string type { get; set; }
        public string videoName { get; set; }

        public string videoLink { get; set; }
        public string description { get; set; }

         
    }
}
