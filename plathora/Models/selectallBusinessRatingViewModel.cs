using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class selectallBusinessRatingViewModel
    {
        public int id { get; set; }

        public string CustomerId { get; set; }
        public string customername { get; set; }
        public int? BusinessOwnerId { get; set; }

        public string rating { get; set; }
        public string comment { get; set; }

        public string profilephoto { get; set; }
        public Boolean isdeleted { get; set; }

    }
}
