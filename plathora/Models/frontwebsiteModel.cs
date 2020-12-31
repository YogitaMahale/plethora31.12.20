using plathora.Entity;
using plathora.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class frontwebsiteModel
    {
        public string  SearchModelType  { get; set; }
        public IEnumerable<SectorRegistrationIndexViewModel> objSectorRegistration { get; set; }
        public IEnumerable<selectallBusinessDetailsDtos> objBusinessDetails { get; set; }
        public IEnumerable<NewIndexViewModel> objNews { get; set; }


        //---------------------------------search query model--------------------------------------

        public IEnumerable<search_BusinessRegistrationIndexViewModel> objsearch_BusinessRegistrationIndexViewModel { get; set; }
        public IEnumerable<search_ProductIndexViewModel> objsearch_ProductIndexViewModel { get; set; }
        public IEnumerable<search_BusinessOwnerRegistrationDtos> objsearch_BusinessOwnerRegistrationDtos { get; set; }
      

    }
}
