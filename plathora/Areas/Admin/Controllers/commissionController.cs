using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Services;

using Microsoft.AspNetCore.Authorization;

using plathora.Utility;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class commissionController : Controller
    {
        private readonly IcommissionServices _commissionServices;
        public commissionController(IcommissionServices commissionServices)
        {
            _commissionServices = commissionServices;

        }

        public IActionResult Index()
        {
            var countrydetails = _commissionServices.GetAll().Select(x => new commissionIndexViewModel
            {
                id = x.id,
                commissionper = x.commissionper,
                

            }).ToList();
            return View(countrydetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new commissionCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(commissionCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new commission
                {
                    id = model.id,
                    commissionper = model.commissionper,
                  
                    isdeleted = false,
                    isactive = false
                };

                await _commissionServices.CreateAsync(objcountry);
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
            var objcountry = _commissionServices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new commissionEditViewModel
            {
                id = objcountry.id,
                commissionper = objcountry.commissionper,

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(commissionEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _commissionServices .GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.commissionper = model.commissionper;


                await _commissionServices.UpdateAsync(objcountry);
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
            await _commissionServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
