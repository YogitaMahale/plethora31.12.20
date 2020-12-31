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
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;

using plathora.Utility;

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BusinessRegistrationController : Controller
    {
        private readonly  ISectorRegistrationServices _SectorRegistrationServices;
        private readonly IBusinessRegistrationServieces _BusinessRegistrationServieces;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public BusinessRegistrationController(ISectorRegistrationServices SectorRegistrationServices, IBusinessRegistrationServieces BusinessRegistrationServieces, IWebHostEnvironment hostingEnvironment)
        {
            _SectorRegistrationServices = SectorRegistrationServices;
            _BusinessRegistrationServieces = BusinessRegistrationServieces;
            _hostingEnvironment =hostingEnvironment;
        }

        public IActionResult Index()
        {
            var statedetails = _BusinessRegistrationServieces.GetAll().Select(x => new BusinessRegistrationIndexViewModel
            {
                id = x.id,
                sectorid = x.sectorid,
                name = x.name,
                SectorRegistration = _SectorRegistrationServices.GetById(x.sectorid),
                img=x.img,
                photo=x.photo

            }).ToList();
            return View(statedetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Allsector= _SectorRegistrationServices.GetAllsector();
            var model = new BusinessRegistrationCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessRegistrationCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new BusinessRegistration
                {
                    id = model.id,
                    sectorid = model.sectorid,
                    name = model.name,
                    isdeleted = false,
                    isactive = false
                };
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/business";
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
                    var uploadDir = @"uploads/business";
                    var fileName = Path.GetFileNameWithoutExtension(model.photo.FileName);
                    var extesion = Path.GetExtension(model.photo.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.photo.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.photo = '/' + uploadDir + '/' + fileName;

                }
                await _BusinessRegistrationServieces.CreateAsync(objcountry);
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
            ViewBag.Allsector = _SectorRegistrationServices.GetAllsector();
            var objbusiness = _BusinessRegistrationServieces.GetById(id);
            if (objbusiness == null)
            {
                return NotFound();
            }
            var model = new BusinessRegistrationEditViewModel
            {
                id = objbusiness.id,
                sectorid = objbusiness.sectorid ,
                name = objbusiness.name ,
                img1 = objbusiness.img,
                photo1 = objbusiness.photo

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusinessRegistrationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objbusiness = _BusinessRegistrationServieces.GetById(model.id);
                if (objbusiness == null)
                {
                    return NotFound();
                }
                objbusiness.id = model.id;
                objbusiness.sectorid = model.sectorid;
                objbusiness.name = model.name;

                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/business";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objbusiness.img = '/' + uploadDir + '/' + fileName;

                }
                if (model.photo != null && model.photo.Length > 0)
                {
                    var uploadDir = @"uploads/business";
                    var fileName = Path.GetFileNameWithoutExtension(model.photo.FileName);
                    var extesion = Path.GetExtension(model.photo.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.photo.CopyToAsync(new FileStream(path, FileMode.Create));
                    objbusiness.photo = '/' + uploadDir + '/' + fileName;

                }
                await _BusinessRegistrationServieces.UpdateAsync(objbusiness);
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
            await _BusinessRegistrationServieces.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
