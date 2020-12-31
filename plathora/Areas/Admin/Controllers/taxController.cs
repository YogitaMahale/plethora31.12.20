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

    public class taxController : Controller
    {
        private readonly ItaxServices _taxServices;


        public taxController(ItaxServices taxServices)
        {
            _taxServices = taxServices;
             
        }

        public IActionResult Index()
        {
            var statedetails = _taxServices.GetAll().Select(x => new taxIndexViewmodel
            {
                id = x.id,
               name=x.name,
               percentage=x.percentage

            }).ToList();
            return View(statedetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
          
            var model = new taxCreateViewmodel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(taxCreateViewmodel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new tax
                {
                    id = model.id,
                   name=model.name,
                   percentage=model.percentage,
                    isdeleted = false,
                    isactive = false
                };

                await _taxServices.CreateAsync(objcountry);
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
           
            var objcountry = _taxServices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new taxEditViewmodel 
            {
                id = objcountry.id,
                name = objcountry.name,
                percentage = objcountry.percentage,

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(taxEditViewmodel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _taxServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.name = model.name;
                objcountry.percentage  = model.percentage;

                await _taxServices.UpdateAsync(objcountry);
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
            await _taxServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
