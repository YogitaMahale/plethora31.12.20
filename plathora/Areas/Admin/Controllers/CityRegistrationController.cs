using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Models;
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

    public class CityRegistrationController : Controller
    {
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        public CityRegistrationController(IStateRegistrationService StateRegistrationService, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices)
        {

            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;

        }


        public IActionResult index()
        {
            var citydetails = _CityRegistrationservices.GetAll().Select(x => new CityIndexViewModel
            {


                id = x.id,
                stateid = x.stateid,
                cityName = x.cityName,
                StateRegistration = _StateRegistrationService.GetById(x.stateid),
                CountryRegistration = _CountryRegistrationservices.GetById(_StateRegistrationService.GetById(x.stateid).countryid)

            }).ToList();
            return View(citydetails);


        }
        public IActionResult test()
        {
            ViewBag.Countrieslist = _CountryRegistrationservices.GetAll().ToList();
            //ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(countryid));
            return View("test");

        }
        
        public JsonResult getstatebyid(int id)
        {

            IList<StateRegistration> obj = _StateRegistrationService.GetAll().Where(x => x.countryid == id).ToList();
            obj.Insert(0, new StateRegistration { id = 0, StateName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj,"id", "StateName"));
        }
        
        public IActionResult GetStates(string countryid)
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(countryid));
            return View("Create");
        }
        [HttpGet]
        public IActionResult Create()
        {
            // ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
          //  ViewBag.StateEnabled = false;
            var model = new CityCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CityCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new CityRegistration
                {

                    id = model.id,
                    stateid = model.stateid,
                    cityName = model.cityName,
                    isdeleted = false,
                    isactive = false
                };

                await _CityRegistrationservices.CreateAsync(objcountry);
                TempData["success"] = "Record Save Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
                TempData["error"] = "Record Not Save";
                return View(model);
            }

        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
        //    var objcountry = _CityRegistrationservices.GetById(id);
        //    if (objcountry == null)
        //    {
        //        return NotFound();
        //    }
        //    var model = new CityEditViewModel
        //    {
        //        id = objcountry.id
        //        ,
        //        stateid = objcountry.stateid
        //        ,
        //        cityName = objcountry.cityName
        //        ,
        //        countryid = _StateRegistrationService.GetById(objcountry.stateid).countryid

        //    };
        //    // ViewBag.StateEnabled = false  ;
        // //   ViewBag.States = _StateRegistrationService.GetAllState(model.countryid);
        //    return View(model);


        //}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            var objcountry = _CityRegistrationservices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new CityEditViewModel
            {
                id = objcountry.id
                ,
                stateid = objcountry.stateid
                ,
                cityName = objcountry.cityName
                ,
                countryid = _StateRegistrationService.GetById(objcountry.stateid).countryid

            };
            // ViewBag.StateEnabled = false  ;
            ViewBag.States = _StateRegistrationService.GetAllState(model.countryid);
            return View(model);


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CityEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _CityRegistrationservices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.stateid = model.stateid;
                objcountry.cityName = model.cityName;


                await _CityRegistrationservices.UpdateAsync(objcountry);
                TempData["success"] = "Record Updated Successfully";
                return RedirectToAction(nameof(index));
            }
            else
            {
                ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
                TempData["error"] = "Record Not Updated";
                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _CityRegistrationservices.Delete(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
