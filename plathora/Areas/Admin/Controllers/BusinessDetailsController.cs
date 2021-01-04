using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Services;

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusinessDetailsController : Controller
    {
        private readonly ISP_Call _sP_Call;
        private readonly IBusinessOwnerRegiServices _businessOwnerRegiServices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public BusinessDetailsController(ISP_Call sP_Call, IBusinessOwnerRegiServices businessOwnerRegiServices, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices, IStateRegistrationService StateRegistrationService, IWebHostEnvironment hostingEnvironment)
        {
            _businessOwnerRegiServices = businessOwnerRegiServices;
            _sP_Call = sP_Call;
            _CountryRegistrationservices = CountryRegistrationservices;
            _StateRegistrationService = StateRegistrationService; 
            _CityRegistrationservices = CityRegistrationservices;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL()
        {
           
            //var paramter = new DynamicParameters();
            //paramter.Add("@type", type);

            IEnumerable<getBusinessAllInfo> obj = _sP_Call.List<getBusinessAllInfo>("selectallBusiness", null );
            return Json(new { data = obj.ToList() });

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var objfromdb = _businessOwnerRegiServices.GetById(id);
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();

            int countryiddd = 0, stateid = 0, countryid = 0;



            if (objfromdb.cityid != null)
            {
                int cityiddd = (int)objfromdb.cityid;
                //  countryiddd = (int)objfromdb.cityid;
                stateid = _CityRegistrationservices.GetById(cityiddd).stateid;
                countryid = _StateRegistrationService.GetById(stateid).countryid;
            }

            if (objfromdb == null)
            {
                return NotFound();
            }
            var model = new EditBusinessDetails
            {


                Id = objfromdb.id,

                facebookLink = objfromdb.facebookLink,
                googleplusLink = objfromdb.googleplusLink,
                instagramLink = objfromdb.instagramLink,
                linkedinLink = objfromdb.linkedinLink,
                twitterLink = objfromdb.twitterLink,

                lic = objfromdb.lic,
                MondayOpen = objfromdb.MondayOpen,
                MondayClose = objfromdb.MondayClose,
                TuesdayOpen = objfromdb.TuesdayOpen,
                TuesdayClose = objfromdb.TuesdayClose,
                WednesdayOpen = objfromdb.WednesdayOpen,
                WednesdayClose = objfromdb.WednesdayClose,
                ThursdayOpen = objfromdb.ThursdayOpen,
                ThursdayClose = objfromdb.ThursdayClose,
                FridayOpen = objfromdb.FridayOpen,
                FridayClose = objfromdb.FridayClose,
                SaturdayOpen = objfromdb.SaturdayOpen,
                SaturdayClose = objfromdb.SaturdayClose,
                SundayOpen = objfromdb.SundayOpen,
                SundayClose = objfromdb.SundayClose,
                house = objfromdb.house,
                landmark = objfromdb.landmark,
                street = objfromdb.street,

                countryid = countryid,
                stateid = stateid,
                cityid = objfromdb.cityid,
                zipcode = objfromdb.zipcode,

                companyName = objfromdb.companyName,

                gstno = objfromdb.gstno,
                Website = objfromdb.Website,
                description = objfromdb.description,
                organization = objfromdb.organization,


                 sliderimg11 = objfromdb.sliderimg1,

                sliderimg21 = objfromdb.sliderimg2,
                sliderimg31 = objfromdb.sliderimg3,
                sliderimg41 = objfromdb.sliderimg4,
                sliderimg51 = objfromdb.sliderimg5



            };
            ViewBag.States = _StateRegistrationService.GetAllState(countryid);
            ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
            return View(model);
            //return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditBusinessDetails model)
        {
            if (ModelState.IsValid)
            {

                var obj1 = _businessOwnerRegiServices.GetById(model.Id);
                if (obj1 == null)
                {
                    return NotFound();
                }

                obj1.id = model.Id;
               // obj1.customerid = model.customerid;
                obj1.description = model.description;
                //obj1.Regcertificate = model.Regcertificate;
                //obj1.businessid = model.businessid;
                //obj1.productid = model.productid;
                obj1.lic = model.lic;
                obj1.MondayOpen = model.MondayOpen;
                obj1.MondayClose = model.MondayClose;
                obj1.TuesdayOpen = model.TuesdayOpen;
                obj1.TuesdayClose = model.TuesdayClose;
                obj1.WednesdayOpen = model.WednesdayOpen;
                obj1.WednesdayClose = model.WednesdayClose;
                obj1.ThursdayOpen = model.ThursdayOpen;
                obj1.ThursdayClose = model.ThursdayClose;
                obj1.FridayOpen = model.FridayOpen;
                obj1.FridayClose = model.FridayClose;
                obj1.SaturdayOpen = model.SaturdayOpen;
                obj1.SaturdayClose = model.SaturdayClose;
                obj1.SundayOpen = model.SundayOpen;
                obj1.SundayClose = model.SundayClose;
                //obj1.CallCount = model.CallCount;
                //obj1.SMSCount = model.SMSCount;
                //obj1.WhatssappCount = model.WhatssappCount;
                //obj1.ShareCount = model.ShareCount;

                obj1.facebookLink = model.facebookLink;
                obj1.googleplusLink = model.googleplusLink;
                obj1.instagramLink = model.instagramLink;
                obj1.linkedinLink = model.linkedinLink;
                obj1.twitterLink = model.twitterLink;
                obj1.youtubeLink = model.youtubeLink;

                // obj.MembershipId = model.MembershipId;
                obj1.house = model.house;
                obj1.landmark = model.landmark;
                obj1.street = model.street;
                obj1.cityid = model.cityid;
                obj1.zipcode = model.zipcode;
                //obj1.latitude = model.latitude;
                //obj1.longitude = model.longitude;
                obj1.companyName = model.companyName;
                obj1.gstno = model.gstno;
                obj1.Website = model.Website;
                //obj1.businessOperation = model.businessOperation;
                //obj1.businessType = model.businessType;


                if (model.sliderimg1 != null)
                {
                    
                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg1.FileName);
                    var extesion = Path.GetExtension(model.sliderimg1.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg1.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg1 = '/' + uploadDir + '/' + fileName;


                     
                }

                if (model.sliderimg2 != null)
                {
                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg2.FileName);
                    var extesion = Path.GetExtension(model.sliderimg2.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg2.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg2 = '/' + uploadDir + '/' + fileName;

                }
                if (model.sliderimg3 != null)
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg3.FileName);
                    var extesion = Path.GetExtension(model.sliderimg3.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg3.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg3 = '/' + uploadDir + '/' + fileName;

                }

                if (model.sliderimg4 != null )
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg4.FileName);
                    var extesion = Path.GetExtension(model.sliderimg4.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg4.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg4 = '/' + uploadDir + '/' + fileName;

                }
                if (model.sliderimg5 != null )
                {

                    var uploadDir = @"uploads/businessowner/slider";
                    var fileName = Path.GetFileNameWithoutExtension(model.sliderimg5.FileName);
                    var extesion = Path.GetExtension(model.sliderimg5.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.sliderimg5.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj1.sliderimg5 = '/' + uploadDir + '/' + fileName;

                }
                await _businessOwnerRegiServices.UpdateAsync(obj1);




                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
                
                int countryiddd = 0, stateid = 0, countryid = 0;



                if (model.cityid != null)
                {
                    countryiddd = (int)model.cityid;
                    stateid = _CityRegistrationservices.GetById(countryiddd).stateid;
                    countryid = _StateRegistrationService.GetById(stateid).countryid;
                }
                ViewBag.States = _StateRegistrationService.GetAllState(countryid);
                ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
                return View(model);
            }

        }





        //public ApplicationUser ApUser { get; set; }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {


            var objfromdb = _businessOwnerRegiServices.GetById(id);
            if (objfromdb != null)
            {

                objfromdb.isdeleted = true;
               await _businessOwnerRegiServices.UpdateAsync(objfromdb);
                return View("Index");
            }
            else
            {
                return View("Index");
            }


        }
        #endregion
    }
}