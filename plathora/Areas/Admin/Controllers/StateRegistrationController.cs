using Microsoft.AspNetCore.Mvc;
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
    public class StateRegistrationController : Controller
    {

        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICityRegistrationservices  _cityRegistrationservices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        public StateRegistrationController(IStateRegistrationService StateRegistrationService, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices cityRegistrationservices)
        {
            _StateRegistrationService = StateRegistrationService;
            _CountryRegistrationservices = CountryRegistrationservices;
            _cityRegistrationservices = cityRegistrationservices;

        }

        public IActionResult Index()
        {
            var statedetails = _StateRegistrationService.GetAll().Select(x => new StateIndexViewModel
            {
                id = x.id,
                countryid = x.countryid,
                StateName = x.StateName,                
                CountryRegistration= _CountryRegistrationservices.GetById(x.countryid)

            }).ToList();
            return View(statedetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Allcountry = _CountryRegistrationservices.GetAllCountry();
            var model = new StateCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StateCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new StateRegistration
                {
                    id = model.id,
                    countryid = model.countryid,
                    StateName  = model.StateName,
                    isdeleted = false,
                    isactive = false
                };

                await _StateRegistrationService.CreateAsync(objcountry);
                TempData["success"] = "Record Save Successfully";
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
            ViewBag.Allcountry = _CountryRegistrationservices.GetAllCountry();
            var objcountry = _StateRegistrationService.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new StateEditViewModel 
            {
                id = objcountry.id,
               countryid  = objcountry.countryid,
                StateName=objcountry.StateName

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StateEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _StateRegistrationService.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
               objcountry.countryid  = model.countryid;
                objcountry.StateName  = model.StateName;


                await _StateRegistrationService.UpdateAsync(objcountry);
                TempData["success"] = "Record Update Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
           


            var obj1 = _cityRegistrationservices.GetAll().Where(x => x.stateid == id && x.isdeleted == false).ToList();
            if (obj1 == null || obj1.Count == 0)
            {
                await _StateRegistrationService.Delete(id);
                TempData["success"] = "State Deleted Successfully";
                return RedirectToAction(nameof(Index));
               
                 
            }
            else
            {

                TempData["error"] = "This State is Not Deleted because City is aded in it";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
