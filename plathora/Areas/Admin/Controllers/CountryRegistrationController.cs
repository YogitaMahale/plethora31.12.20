using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using plathora.Services;
using Microsoft.AspNetCore.Mvc;
using plathora.Models;
using plathora.Entity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using plathora.pagination;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CountryRegistrationController : Controller
    {
        
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly IStateRegistrationService _stateRegistrationService;
        public CountryRegistrationController(ICountryRegistrationservices CountryRegistrationservices, IStateRegistrationService stateRegistrationService)
        {
            _CountryRegistrationservices = CountryRegistrationservices;
            _stateRegistrationService = stateRegistrationService;
        }
     
        public IActionResult Index()
        {
            var countrydetails = _CountryRegistrationservices.GetAll().Select(x => new CountryIndexViewModel
            {
                id = x.id,
                countrycode  = x.countrycode,
                countryname = x.countryname

            }).ToList();
             return View(countrydetails);
            
            
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new CountryCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CountryCreateViewModel model)
        {
             
            if (ModelState.IsValid)
            {
                var objcountry = new CountryRegistration
                {
                    id = model.id,
                    countryname = model.countryname,
                    countrycode = "",
                    isdeleted=false,
                    isactive=false
                };
 
                await _CountryRegistrationservices.CreateAsync(objcountry);
                TempData["success"] = "Record Save successfully";
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
            var objcountry = _CountryRegistrationservices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new CountryEditViewModel
            {
                id = objcountry.id,
                countryname = objcountry.countryname,
                
            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CountryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _CountryRegistrationservices .GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.countryname = model.countryname;
                
                 
                await _CountryRegistrationservices .UpdateAsync(objcountry);
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }


        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var emp = _AffiltateRegistrationService.GetById(id);
        //    if (emp == null)
        //    {
        //        return NotFound();

        //    }
        //    AffiltateRegistrationDeleteViewModel model = new AffiltateRegistrationDeleteViewModel()
        //    {
        //        id = emp.id,
        //        name = emp.name
        //    };


        //    return View(model);
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {          

            var obj1 = _stateRegistrationService.GetAll().Where(x => x.countryid == id && x.isdeleted == false).ToList();
            if (obj1 == null || obj1.Count == 0)
            {
                await _CountryRegistrationservices.Delete(id);
                TempData["success"] = "Country Deleted Successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {

                TempData["error"] = "This Country is Not Deleted because State is aded in it";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
