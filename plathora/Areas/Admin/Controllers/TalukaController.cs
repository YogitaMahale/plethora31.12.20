using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Models;
//using plathora.Persistence.Migrations;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Authorization;

using plathora.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class TalukaController : Controller
    {
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly ITalukaServices _TalukaServices;

        public TalukaController(IStateRegistrationService StateRegistrationService, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices, ITalukaServices TalukaServices)
        {

            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;
            _TalukaServices = TalukaServices;
        }


        public IActionResult index()
        {
            var citydetails = _TalukaServices.GetAll().Select(x => new TalukaIndexViewmodel
            {


                id = x.id,

                cityid = x.cityid,
                talukaname = x.talukaname,
                CityRegistration = _CityRegistrationservices.GetById(x.cityid),
                stateid =  _CityRegistrationservices.GetById(x.cityid).stateid,
               

                //StateRegistration = _StateRegistrationService.GetById(),
                //CountryRegistration = _CountryRegistrationservices.GetById(_StateRegistrationService.GetById(x.stateid).countryid)

            }).ToList();
            return View(citydetails);
         //   id, cityid, talukaname, isdeleted, isactive

        }

        public JsonResult getCitybyStateid(int stateid)
        {

            IList<CityRegistration> obj = _CityRegistrationservices.GetAll().Where(x => x.stateid == stateid).ToList();
            obj.Insert(0, new CityRegistration { id = 0, cityName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "cityName"));
        }

        public JsonResult getstatebyid(int id)
        {

            IList<StateRegistration> obj = _StateRegistrationService.GetAll().Where(x => x.countryid == id).ToList();
            obj.Insert(0, new StateRegistration { id = 0, StateName = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "StateName"));
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
            var model = new TalukaCreateViewmodel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TalukaCreateViewmodel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new Taluka
                {
                    
  
                    id = model.id,
                    cityid = model.cityid,
                    talukaname = model.talukaname,
                    isdeleted = false,
                    isactive = false
                };

                await _TalukaServices.CreateAsync(objcountry);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }
       
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            var objcountry = _TalukaServices.GetById(id);
            int stateid = _CityRegistrationservices.GetById(objcountry.cityid).stateid;
            int countryid = _StateRegistrationService.GetById(stateid).countryid ;
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new TalukaEditViewmodel
            {
                id = objcountry.id
                ,

                cityid = objcountry.cityid
                ,
                talukaname = objcountry.talukaname

                , stateid = stateid,
                countryid = countryid

            };
            // ViewBag.StateEnabled = false  ;
            ViewBag.States = _StateRegistrationService.GetAllState(model.countryid);
            ViewBag.Cities = _CityRegistrationservices.GetAllCity(model.stateid);
            return View(model);


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TalukaEditViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _TalukaServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.cityid = model.stateid;
                objcountry.talukaname = model.talukaname;


                await _TalukaServices.UpdateAsync(objcountry);
                return RedirectToAction(nameof(index));
            }
            else
            {
                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _TalukaServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
