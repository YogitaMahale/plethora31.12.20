using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plathora.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.IO;
using Microsoft.AspNetCore.Hosting;

using System;
using Microsoft.AspNetCore.Authorization;
using plathora.Services;
using plathora.Entity;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class referfriendController : Controller
    {
        
        private readonly IreferfriendSliderServices _referfriendSliderServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
       
        public referfriendController(IreferfriendSliderServices referfriendSliderServices
                               , IWebHostEnvironment hostingEnvironment
                                )
        {
            _hostingEnvironment = hostingEnvironment;
            _referfriendSliderServices = referfriendSliderServices;
           
        }
        public async Task<IActionResult> Index()
        {
           
            var listt = _referfriendSliderServices.GetAll().Where(x => x.isdeleted == false).Select(x => new referfriendIndexViewModel
            {
                id = x.id
                   ,
                name = x.name
                 
            }).ToList();
            //  return View(storeList);


            return View(listt);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            

            
            var model = new referfriendCreateViewModel();
            return View(model);
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(referfriendCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                var store = new referfriendSlider
                {
                     
                    id = model.id,
                    
                    isdeleted = false
                    ,
                    isactive = false
                   

                };
                if (model.name != null && model.name.Length > 0)
                {
                    var uploadDir = @"uploads/referfriendSlider";
                    var fileName = Path.GetFileNameWithoutExtension(model.name.FileName);
                    var extesion = Path.GetExtension(model.name.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.name.CopyToAsync(new FileStream(path, FileMode.Create));
                    store.name = '/' + uploadDir + '/' + fileName;

                }
                await _referfriendSliderServices .CreateAsync(store);
              //  TempData["success"] = "Record Saved successfully";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();

            }
        }


        public async Task<IActionResult> Edit(int id)
        {
            

             
            var prod = _referfriendSliderServices.GetById(id);
            if (prod == null)
            {
                return NotFound();
            }
            var model = new referfriendCreateViewModel()
            {
                id = prod.id,
               // name = prod.name,
                

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(referfriendCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var storeobj = _referfriendSliderServices .GetById(model.id);
                if (storeobj == null)
                {
                    return NotFound();
                }
                storeobj.id = model.id;
                 

                if (model.name != null && model.name.Length > 0)
                {
                    var uploadDir = @"uploads/referfriendSlider";
                    var fileName = Path.GetFileNameWithoutExtension(model.name.FileName);
                    var extesion = Path.GetExtension(model.name.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.name.CopyToAsync(new FileStream(path, FileMode.Create));
                    storeobj.name = '/' + uploadDir + '/' + fileName;

                }

                await _referfriendSliderServices.UpdateAsync(storeobj);
                //TempData["success"] = "Record Updated successfully";
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
            await _referfriendSliderServices.Delete(id);
        //    TempData["success"] = "Record Delete successfully";
            return RedirectToAction(nameof(Index));



        }
    }
}
