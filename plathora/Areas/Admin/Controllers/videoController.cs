using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Services;
 
using plathora.Services.Implementation;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class videoController : Controller
    {

        private readonly IVideoServices _videoServices;
        private readonly IModuleMasterServices _moduleMasterServices;
        public videoController(IVideoServices videoServices, IModuleMasterServices moduleMasterServices)
        {
            _videoServices = videoServices;
            _moduleMasterServices = moduleMasterServices;

        }
       

        public IActionResult index()
        {
            var citydetails = _videoServices.GetAll().Select(x => new VideoIndexViewModel
            {


             
                id = x.id,
                fkmoduleid=x.fkmoduleid,
                type=x.type,
                videoName=x.videoName,
                videoLink=x.videoLink,
                description=x.description,
               modulename=_moduleMasterServices.GetById(x.fkmoduleid).Name

            }).ToList();
            return View(citydetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ModuleList = _moduleMasterServices.GetAll().ToList();
            //  ViewBag.StateEnabled = false;
            var model = new VideoCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VideoCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new Videos
                {                   

                    id=model.id,
                    fkmoduleid = model.fkmoduleid,
                    type = model.type,
                    videoName = model.videoName,
                    videoLink = model.videoLink,
                    description = model.description,
                    isdeleted = false,
                    isactive=false
                };
                 
                await _videoServices.CreateAsync(objcountry);
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
            ViewBag.ModuleList = _moduleMasterServices.GetAll().ToList();
            var obj1 = _videoServices.GetById(id);
            if (obj1 == null)
            {
                return NotFound();
            }
            var model = new VideoEditViewModel
            {
               
                id= obj1.id,
                fkmoduleid = obj1.fkmoduleid,
                type = obj1.type,
                videoName = obj1.videoName,
                videoLink = obj1.videoLink,
                description = obj1.description,
                isdeleted = obj1.isdeleted ,
                isactive = obj1.isactive 
            };
            
          
            return View(model);


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VideoEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _videoServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.fkmoduleid = model.fkmoduleid;
                objcountry.type = model.type;

                objcountry.videoName = model.videoName;
                objcountry.videoLink = model.videoLink;
                objcountry.description = model.description;

               

                  await _videoServices.UpdateAsync(objcountry);
                return RedirectToAction(nameof(index));
            }
            else
            {
                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _videoServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}