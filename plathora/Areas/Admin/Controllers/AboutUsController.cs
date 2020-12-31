//using appFoodDelivery.Entity;
//using appFoodDelivery.Models;
using appFoodDelivery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Services;
using plathora.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace appFoodDelivery.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    // [Authorize(Roles = SD.Role_Admin)]
    public class AboutUsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAboutUsServices _AboutUsServices;
        public AboutUsController(IAboutUsServices AboutUsServices, IWebHostEnvironment hostingEnvironment)
        {
            _AboutUsServices =AboutUsServices;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit()
        {
            var storeowner = _AboutUsServices.GetById(1);
            if (storeowner == null)
            {
                return NotFound();
            }
            var model = new AboutUsViewModel()
            {
                id = storeowner.id,
                AboutUsText = storeowner.AboutUsText,
                PurposeoftheCompany=storeowner.PurposeoftheCompany,
                imgpath= storeowner.img


            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutUsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _AboutUsServices.GetById(model.id);
                if (storeobj == null)
                {
                    TempData["error"] = "Record Not Found";
                    return NotFound();
                }
                storeobj.id = model.id;
                storeobj.AboutUsText = model.AboutUsText ;
                storeobj.PurposeoftheCompany = model.PurposeoftheCompany;
                

                if (model.img != null && model.img.Length > 0)
                {
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    var uploadDir = @"uploads/AboutUs";
                    //// var filePath =  Server.MapPath("~/Images/" + filename);
                    //string ss = webRootPath  + storeobj.img;
                    //if (System.IO.File.Exists(ss))
                    //{
                    //    System.IO.File.Delete(ss);
                    //}
                    //------------

                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                   // var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.img = '/' + uploadDir + '/' + fileName;

                }
                await _AboutUsServices.UpdateAsync(storeobj);
                TempData["success"] = "Record Update successfully";
                return RedirectToAction(nameof(Edit));
            }
            else
            {
                return View();
            }

        }

    }
}
