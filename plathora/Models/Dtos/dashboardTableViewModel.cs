using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models.Dtos
{
    public class dashboardTableViewModel
    {
        public int id { get; set; }
        public string  date { get; set; }
        public int customer { get; set; }
        public int affilate { get; set; }
    }
}
