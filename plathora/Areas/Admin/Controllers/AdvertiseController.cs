using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Services;
using plathora.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AdvertiseController : Controller
    {
        private readonly IAdvertiseServices _AdvertiseServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AdvertiseController(IAdvertiseServices AdvertiseServices, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _AdvertiseServices = AdvertiseServices;            

        }

        public IActionResult Index()
        {
            var statedetails = _AdvertiseServices.GetAll().Select(x => new AdvertiseIndexViewModel
            {
                id = x.id,
               name=x.name,
                Amount = x.Amount,
                description = x.description,
                period = x.period,
                img=x.img,
                gst=x.gst,
                affilateamt=x.affilateamt,
                plethoraamt=x.plethoraamt

            }).ToList();
            return View(statedetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            
            var model = new AdvertiseCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdvertiseCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new Advertise
                {
                    id = model.id,
                    name=model.name,
                    Amount = model.Amount,
                    description = model.description,
                    period = model.period,
                    isdeleted = false,
                    isactive = false,
                    gst=model.gst ,
                    affilateamt=model.affilateamt,
                    plethoraamt=model.plethoraamt
                };
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/AdvertiseMaster";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.img = '/' + uploadDir + '/' + fileName;

                }
                await _AdvertiseServices.CreateAsync(objcountry);
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
             
            var objcountry = _AdvertiseServices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new AdvertiseEditViewModel
            {
                id = objcountry.id,
                 name=objcountry.name,
                Amount = objcountry.Amount,
                description = objcountry.description,
                period = objcountry.period,
                gst=objcountry.gst,
                img1=objcountry.img,
                affilateamt=objcountry.affilateamt,
                plethoraamt=objcountry.plethoraamt

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdvertiseEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _AdvertiseServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.name = model.name;

                objcountry.description = model.description;
                objcountry.Amount = model.Amount;
                objcountry.period = model.period;
                objcountry.gst = model.gst;

                objcountry.plethoraamt  = model.plethoraamt;
                objcountry.affilateamt = model.affilateamt;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/AdvertiseMaster";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.img = '/' + uploadDir + '/' + fileName;

                }
                await _AdvertiseServices.UpdateAsync(objcountry);
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
            await _AdvertiseServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
