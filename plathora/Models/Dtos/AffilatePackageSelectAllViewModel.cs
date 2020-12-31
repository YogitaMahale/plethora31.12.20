using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class AffilatePackageSelectAllViewModel
    {
         
        public int id { get; set; }

        public int membershipid { get; set; }
        public int commissionid { get; set; }
        public decimal  amount { get; set; }
        public string  Description { get; set; }
        public bool  isdeleted { get; set; }
        public bool  isactive   { get; set; }
        public string membershipname { get; set; }
        public string commissionper { get; set; }
        public decimal  gst { get; set; }

        public decimal affilateamt { get; set; }
        public decimal plethoraamt { get; set; }

    }
}
