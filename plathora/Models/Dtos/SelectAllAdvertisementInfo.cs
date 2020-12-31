using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class SelectAllAdvertisementInfo
    {
        public int id { get; set; }
        public int? affilateid { get; set; }
        public int cusotmerid { get; set; }       
        public int advertiseid { get; set; }


        public string customerName { get; set; }
        public string affilateName { get; set; }
        public string AdvertiseName { get; set; }

        public DateTime startdate { get; set; }
        public string title { get; set; }
        public string videourl { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }       
        public Boolean isdeleted { get; set; }
    }
}
