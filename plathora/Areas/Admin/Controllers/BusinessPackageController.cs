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

    public class BusinessPackageController : Controller
    {
        private readonly IPackageRegistrationServices _PackageRegistrationServices;
        private readonly IBusinessPackageServices _BusinessPackageServices;
        public BusinessPackageController(IPackageRegistrationServices PackageRegistrationServices, IBusinessPackageServices BusinessPackageServices)
        {
            _PackageRegistrationServices = PackageRegistrationServices;
            _BusinessPackageServices =BusinessPackageServices;

        }

        public IActionResult Index()
        {
            var statedetails = _BusinessPackageServices.GetAll().Select(x => new BusinessPackageIndexViewModel
            {
                id = x.id,
                pkgId  = x.pkgId,
                Amount = x.Amount,
                description = x.description,
                period = x.period,
                PackageRegistration = _PackageRegistrationServices.GetById(x.pkgId),
                gst=x.gst,
                affilateamt=x.affilateamt,
                plethoraamt=x.plethoraamt

            }).ToList();
            return View(statedetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllPackage = _PackageRegistrationServices.GetAllPackage();
            var model = new BusinessPackageCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessPackageCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new BusinessPackage
                {
                    id = model.id,
                    pkgId = model.pkgId,
                    Amount = model.Amount,
                    description = model.description,
                    period = model.period,
                    isdeleted = false,
                    isactive = false,
                    gst=model.gst,
                    affilateamt=model.affilateamt,
                    plethoraamt=model.plethoraamt
                };

                await _BusinessPackageServices.CreateAsync(objcountry);
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
            ViewBag.AllPackage = _PackageRegistrationServices.GetAllPackage();
            var objcountry = _BusinessPackageServices .GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new BusinessPackageEditViewModel
            {
                id = objcountry.id,
               pkgId  = objcountry.pkgId,
                Amount = objcountry.Amount,
                description = objcountry.description,
                period  = objcountry.period,
                gst=objcountry.gst,
                plethoraamt=objcountry.plethoraamt,
                affilateamt=objcountry.affilateamt

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusinessPackageEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _BusinessPackageServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.pkgId = model.pkgId;
                objcountry.description  = model.description;
                objcountry.Amount  = model.Amount;
                objcountry.period  = model.period;
                objcountry.gst = model.gst;

                objcountry.affilateamt = model.affilateamt;
                objcountry.plethoraamt = model.plethoraamt;
                await _BusinessPackageServices.UpdateAsync(objcountry);
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
            await _BusinessPackageServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
