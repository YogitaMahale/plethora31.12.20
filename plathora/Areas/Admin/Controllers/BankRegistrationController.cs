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

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BankRegistrationController : Controller
    {
        private readonly IBankRegistrationServices _BankRegistrationServices;
        public BankRegistrationController(IBankRegistrationServices BankRegistrationServices)
        {
            _BankRegistrationServices = BankRegistrationServices;

        }

        public IActionResult Index()
        {
            var countrydetails = _BankRegistrationServices.GetAll().Select(x => new BankRegistrationIndexViewModel
            {
                id = x.id,
                name = x.name

            }).ToList();
            return View(countrydetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new BankRegistrationCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankRegistrationCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new BankRegistration
                {
                    id = model.id,
                    name = model.name,

                    isdeleted = false,
                    isactive = false
                };

                await _BankRegistrationServices.CreateAsync(objcountry);
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
            var objcountry = _BankRegistrationServices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new BankRegistrationEditViewModel
            {
                id = objcountry.id,
                name = objcountry.name,

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BankRegistrationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _BankRegistrationServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.name = model.name;


                await _BankRegistrationServices.UpdateAsync(objcountry);
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
            await _BankRegistrationServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
