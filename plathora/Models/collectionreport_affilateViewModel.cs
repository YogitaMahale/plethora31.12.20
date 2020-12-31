using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class collectionreport_affilateViewModel
    {
        // Id,name,PhoneNumber ,pkgamount,gstamt,createddate
        public string Id { get; set; }
        public string name { get; set; }
        public string PhoneNumber { get; set; }
        public string createddate { get; set; }
        public string AffilatePackageid { get; set; } 
        public string  AffilatePackageName { get; set; }
        public decimal gst { get; set; }



        public decimal gstAmount { get; set; }
        public decimal AffilatePackageAmount { get; set; }
        public decimal commissionper { get; set; }
        public decimal commission1 { get; set; }
        public decimal tds { get; set; }
        public decimal commissionAmount { get; set; }
        public decimal PaymentAmount { get; set; }

        public decimal plethoraamt { get; set; }



    }
}
