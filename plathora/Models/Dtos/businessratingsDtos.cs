using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class businessratingsDtos
    {

        public string? CustomerId { get; set; }
        public int? BusinessOwnerId { get; set; }

        public string rating { get; set; }
        public string comment { get; set; }

       
        
    }
}
