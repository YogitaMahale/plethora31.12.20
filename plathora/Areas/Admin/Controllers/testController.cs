using Microsoft.AspNetCore.Mvc;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

using plathora.Utility;

namespace plathora.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class testController : Controller
    {
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        public testController(IStateRegistrationService StateRegistrationService, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices)
        {

            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;

        }

        ////*******
        private void FillCountries()
        {


            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
        }
        private void FillStates(string country = "")
        {

            ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(country));
        }

        public IActionResult Index()
        {
            FillCountries();
            ViewBag.StateEnabled = false;
            return View();
        }

        public IActionResult GetStates(string country)
        {
            FillCountries();
            FillStates(country);
            return View("Index");
        }
        public IActionResult ProcessForm()
        {
            FillCountries();
            return View("Index");
        }


    }
}
