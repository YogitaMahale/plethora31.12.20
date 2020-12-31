using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class advertisementInfoDtos
    {

  //      id,  ,  ,  ,  ,  ,  ,  ,  , 
  //          isdeleted, Expirydate,
  //PaymentAmount, PaymentStatus,  , TransactionId, 
        // public int id { get; set; }
        public string customerId { get; set; }
         
        public int advertiseid { get; set; }
        public DateTime startdate { get; set; }
        public string title { get; set; }
        public string videourl { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }

        public decimal PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionId { get; set; }

        public string uniqueId { get; set; }

    }
}
