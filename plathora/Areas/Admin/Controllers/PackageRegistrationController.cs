using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plathora.Services;
using plathora.Entity;
using plathora.Models;

using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class PackageRegistrationController : Controller
    {
        private readonly IPackageRegistrationServices _PackageRegistrationServices;
        public PackageRegistrationController(IPackageRegistrationServices PackageRegistrationServices)
        {
            _PackageRegistrationServices = PackageRegistrationServices;

        }

        public IActionResult Index()
        {
            var pkgdetails = _PackageRegistrationServices.GetAll().Select(x => new PackageRegistrationIndexViewModel
            {
                id = x.id,
                name = x.name

            }).ToList();
            return View(pkgdetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new PackageRegistrationCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PackageRegistrationCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objpkg = new PackageRegistration 
                {
                    id = model.id,
                    name = model.name,

                    isdeleted = false,
                    isactive = false
                };

                await _PackageRegistrationServices.CreateAsync(objpkg);
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
            var objpkg = _PackageRegistrationServices.GetById(id);
            if (objpkg == null)
            {
                return NotFound();
            }
            var model = new PackageRegistrationEditViewModel
            {
                id = objpkg.id,
                name = objpkg.name,

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PackageRegistrationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objpkg = _PackageRegistrationServices.GetById(model.id);
                if (objpkg == null)
                {
                    return NotFound();
                }
                objpkg.id = model.id;
                objpkg.name = model.name;


                await _PackageRegistrationServices.UpdateAsync(objpkg);
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
            await _PackageRegistrationServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
