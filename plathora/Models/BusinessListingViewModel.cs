using plathora.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class BusinessListingViewModel
    {
       // public getBusinessAllInfo objgetBusinessAllInfo { get; set; }
        public IEnumerable<ProductIndexViewModel> objProductIndexViewModel { get; set; }
        //   public IEnumerable<selectallBusinessDetailsDtos> objBusinessDetails { get; set; }
        public IEnumerable<getBusinessAllInfo> objgetBusinessAllInfo { get; set; }
    }
}
