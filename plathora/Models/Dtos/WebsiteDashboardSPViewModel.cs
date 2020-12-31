using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class WebsiteDashboardSPViewModel
    {
        public int CustomerCnt { get; set; }
        public int CustomerOnlineCnt { get; set; }
        public int CustomerOfflineCount { get; set; }
        public int AffilateOnlineCnt { get; set; }
        public int AffilateCnt { get; set; }
        public int AffilateOfflineCount { get; set; }
        public int totalbusinessCount { get; set; }
        public int totalbusiness { get; set; }
                  

    }
}
