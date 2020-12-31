using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    public class SectorRegistrationController : Controller
    {
        private readonly ISectorRegistrationServices _SectorRegistrationServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SectorRegistrationController(ISectorRegistrationServices SectorRegistrationServices, IWebHostEnvironment hostingEnvironment)
        {
            _SectorRegistrationServices = SectorRegistrationServices;
            _hostingEnvironment = hostingEnvironment;

        }

        public IActionResult Index()
        {
            var countrydetails = _SectorRegistrationServices.GetAll().Select(x => new SectorRegistrationIndexViewModel
            {
                id = x.id,
                name=x.name,img=x.img,
                photo=x.photo

            }).ToList();
            return View(countrydetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new SectorRegistrationCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SectorRegistrationCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new SectorRegistration
                {
                    id = model.id,
                    name = model.name,
                     
                    isdeleted = false,
                    isactive = false,
                   
                };
                if (model.img  != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/sector";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.img = '/' + uploadDir + '/' + fileName;

                }
                if (model.photo != null && model.photo.Length > 0)
                {
                    var uploadDir = @"uploads/sector";
                    var fileName = Path.GetFileNameWithoutExtension(model.photo.FileName);
                    var extesion = Path.GetExtension(model.photo.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.photo.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.photo = '/' + uploadDir + '/' + fileName;

                }
                await _SectorRegistrationServices.CreateAsync(objcountry);
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
            var objcountry = _SectorRegistrationServices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new SectorRegistrationEditViewModel
            {
                id = objcountry.id,
                name = objcountry.name,
                img1 = objcountry.img,
                photo1 = objcountry.photo



            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SectorRegistrationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _SectorRegistrationServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.name  = model.name ;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/sector";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.img = '/' + uploadDir + '/' + fileName;

                }
                if (model.photo != null && model.photo.Length > 0)
                {
                    var uploadDir = @"uploads/sector";
                    var fileName = Path.GetFileNameWithoutExtension(model.photo.FileName);
                    var extesion = Path.GetExtension(model.photo.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.photo.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.photo = '/' + uploadDir + '/' + fileName;

                }
                await _SectorRegistrationServices.UpdateAsync(objcountry);
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
            await _SectorRegistrationServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
