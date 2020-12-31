using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using plathora.Models;
//using plathora.Persistence.Migrations;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISectorRegistrationServices _SectorRegistrationServices;
        private readonly IBusinessRegistrationServieces _BusinessRegistrationServiecess;
        private readonly IProductMasterServices _ProductMasterServices;
        public ProductController(ISectorRegistrationServices SectorRegistrationServices, IBusinessRegistrationServieces BusinessRegistrationServiecess, IProductMasterServices ProductMasterServices, IWebHostEnvironment hostingEnvironment)
        {

            _SectorRegistrationServices = SectorRegistrationServices;
            _BusinessRegistrationServiecess = BusinessRegistrationServiecess;
            _ProductMasterServices = ProductMasterServices;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult index()
        {
            var citydetails = _ProductMasterServices.GetAll().Select(x => new ProductIndexViewModel
            {


                id = x.id,
               //sectorid = x.se,
                businessid  = x.businessid,
                productName=x.productName, 
                 BusinessRegistration = _BusinessRegistrationServiecess.GetById(x.businessid ),
                SectorRegistration = _SectorRegistrationServices.GetById(_BusinessRegistrationServiecess.GetById(x.businessid).sectorid),
                img=x.img

            }).ToList();
            return View(citydetails);


        }

      
        public JsonResult getBusinessRegbySectorid(int sectorid)
        {

            IList<BusinessRegistration> obj = _BusinessRegistrationServiecess.GetAll().Where(x => x.sectorid == sectorid).ToList();
            obj.Insert(0, new BusinessRegistration { id = 0, name = "select", isactive = false, isdeleted = false });
            return Json(new SelectList(obj, "id", "name"));
        }
         
        //public IActionResult GetStates(string countryid)
        //{
        //    ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
        //    ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(countryid));
        //    return View("Create");
        //}
        [HttpGet]
        public IActionResult Create()
        {
            // ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.SectorList = _SectorRegistrationServices.GetAll().ToList();
            //  ViewBag.StateEnabled = false;
            var model = new ProductCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new ProductMaster
                {

                    id = model.id,
                    businessid = model.businessid,
                    productName = model.productName,
                    isdeleted = false,
                    isactive = false
                };
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.img = '/' + uploadDir + '/' + fileName;

                }
                await _ProductMasterServices.CreateAsync(objcountry);
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
            ViewBag.SectorList = _SectorRegistrationServices.GetAll().ToList();
            var objcountry = _ProductMasterServices .GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new ProductEditViewModel
            {
                id = objcountry.id
                ,
                businessid = objcountry.businessid
                ,
                productName = objcountry.productName
                ,
                sectorid = _BusinessRegistrationServiecess.GetById(objcountry.businessid).sectorid,
                img1=objcountry.img

            };
             ViewBag.StateEnabled = false  ;
            ViewBag.business = _BusinessRegistrationServiecess.GetAllBusiness(model.sectorid);
            return View(model);


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _ProductMasterServices .GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.businessid = model.businessid;
                objcountry.productName = model.productName;
                if (model.img != null && model.img.Length > 0)
                {
                    var uploadDir = @"uploads/product";
                    var fileName = Path.GetFileNameWithoutExtension(model.img.FileName);
                    var extesion = Path.GetExtension(model.img.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.img.CopyToAsync(new FileStream(path, FileMode.Create));
                    objcountry.img = '/' + uploadDir + '/' + fileName;

                }

                await _ProductMasterServices.UpdateAsync(objcountry);
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
            await _ProductMasterServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }



    }
}