using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace plathora.Models
{
    public class TalukaIndexViewmodel
    {
        public int id { get; set; }


        public int countryid { get; set; }
        public int stateid { get; set; }
        public int cityid { get; set; }

        public string talukaname { get; set; }


        public CountryRegistration CountryRegistration { get; set; }

        public StateRegistration StateRegistration { get; set; }
        public CityRegistration CityRegistration { get; set; }


      

    }
}
