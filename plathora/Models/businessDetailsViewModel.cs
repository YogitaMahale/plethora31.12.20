using plathora.Entity;
using plathora.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class businessDetailsViewModel
    {
        public getBusinessAllInfo objgetBusinessAllInfo { get; set; }
        public IEnumerable<selectallBusinessRatingViewModel> objbusinessrating { get; set; }
    }
}
