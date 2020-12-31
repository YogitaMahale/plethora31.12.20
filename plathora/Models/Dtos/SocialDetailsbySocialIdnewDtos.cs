using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class SocialDetailsbySocialIdnewDtos
    {
        public int id { get; set; }

        public int socialid { get; set; }
        public string  customerid { get; set; }

        public int LikeCnt { get; set; }
        public string comment { get; set; }

       // id, socialid, customerid, LikeCnt, comment, isdeleted
        public string customerName { get; set; }
         
    }
}
