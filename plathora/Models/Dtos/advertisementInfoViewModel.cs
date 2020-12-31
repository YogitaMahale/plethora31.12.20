using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class advertisementInfoViewModel
    {
        public int id { get; set; }
     
        public string customerId { get; set; }
        public string customername { get; set; }
       


        
        public int? advertiseid { get; set; } = null;
        
        public DateTime startdate { get; set; }
        public string title { get; set; }
        public string videourl { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }



        
        
        //paymnet details
        public DateTime Registrationdate { get; set; } = DateTime.UtcNow;
        public DateTime Expirydate { get; set; }
        public string PaymentStatus { get; set; }
        
        public decimal PaymentAmount { get; set; }
        public string TransactionId { get; set; }

        public string AfilateuniqueId { get; set; }
    }
}
