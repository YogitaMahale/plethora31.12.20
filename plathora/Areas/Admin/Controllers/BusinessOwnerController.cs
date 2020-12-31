using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using plathora.Services;
using Microsoft.AspNetCore.Mvc;
using plathora.Models;
using plathora.Entity;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using plathora.pagination;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BusinessOwnerController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IBusinessOwnerRegiServices _BusinessOwnerRegiServices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly IProductMasterServices _ProductMasterServices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ISectorRegistrationServices _SectorRegistrationServices;
        private readonly IBusinessRegistrationServieces _BusinessRegistrationServieces;
        public BusinessOwnerController(IBusinessOwnerRegiServices BusinessOwnerRegiServices, IWebHostEnvironment hostingEnvironment, ICountryRegistrationservices CountryRegistrationservices, ICityRegistrationservices CityRegistrationservices, ISectorRegistrationServices SectorRegistrationServices, IProductMasterServices ProductMasterServices, IStateRegistrationService StateRegistrationService, IBusinessRegistrationServieces BusinessRegistrationServieces)
        {
            _BusinessOwnerRegiServices = BusinessOwnerRegiServices;
            _hostingEnvironment = hostingEnvironment;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;
            _SectorRegistrationServices = SectorRegistrationServices;
            _ProductMasterServices = ProductMasterServices;
            _StateRegistrationService = StateRegistrationService;
            _BusinessRegistrationServieces = BusinessRegistrationServieces;
        }
        /*
        public IActionResult Index(int? PageNumber)
        {
            var affilatemaster = _BusinessOwnerRegiServices.GetAll().Select(x => new BusinessOwnerIndexViewModel
            {
                id = x.id,
                name = x.name,
                profilephoto = x.profilephoto,
                mobileno1 = x.mobileno1,
                DOB = x.DOB,
                createddate = x.createddate,

            }).ToList();
            // return View(affilatemaster);
            int PageSize = 4;
            return View(BusinessOwnerPagination<BusinessOwnerIndexViewModel>.Create(affilatemaster, PageNumber ?? 1, PageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
            ViewBag.SectorList = _SectorRegistrationServices.GetAll().ToList();
            var model = new BusinessOwnerCreateViewModel();
            return View(model);
        }
        public JsonResult getProductbyBusinessid(int businessid)
        {

            IEnumerable<SelectListItem> obj = _ProductMasterServices.GetAllProuct_SelectListItem(businessid);
            //obj.Insert(0, new StateRegistration { id = 0, StateName = "select", isactive = false, isdeleted = false });

            return Json(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessOwnerCreateViewModel model)
        {
            // id, name, profilephoto, mobileno1, mobileno2, emailid1, emailid2
            //, adharcardno, adharcardphoto, pancardno, pancardphoto, password
            //, gender, DOB, createddate
            if (ModelState.IsValid)
            {

                var obj = new BusinessOwnerRegi
                {
                    id = model.id
                    ,
                    name = model.name
                    //  , profilephoto = model.profilephoto
                    ,
                    mobileno1 = model.mobileno1
                    ,
                    mobileno2 = model.mobileno2
                    ,
                    emailid1 = model.emailid1
                    ,
                    emailid2 = model.emailid2
                    ,
                    adharcardno = model.adharcardno
                    //, adharcardphoto = model.id
                    ,
                    pancardno = model.pancardno
                    //,   pancardphoto = model.id
                    ,
                    password = model.password
                    ,
                    gender = model.gender
                    ,
                    pinno = model.pinno
                    ,
                    DOB = model.DOB
                    ,
                    createddate = model.createddate
                    ,
                    isdeleted = false
                    ,
                    isactive = false
                    ,
                    house = model.house
                    ,
                    landmark = model.landmark
                    ,
                    street = model.street
                    ,
                    cityid = model.cityid
                    ,
                    zipcode = model.zipcode
                    ,
                    latitude = model.latitude
                    ,
                    longitude = model.longitude
                    ,
                    companyName = model.companyName
                    ,
                    designation = model.designation
                    ,
                    gstno = model.gstno
                    ,
                    Website = model.Website
                    ,
                    Discription = model.Discription
                    ,
                    Regcertificate = model.Regcertificate
                    ,
                    productid = model.productid
                    ,
                    lic = model.lic




                };

                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/BusinessOwner/profilephoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj.profilephoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.pancardphoto != null && model.pancardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/BusinessOwner/pancardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.pancardphoto.FileName);
                    var extesion = Path.GetExtension(model.pancardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.pancardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj.pancardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.adharcardphoto != null && model.adharcardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/BusinessOwner/adharcardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.adharcardphoto.FileName);
                    var extesion = Path.GetExtension(model.adharcardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.adharcardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    obj.adharcardphoto = '/' + uploadDir + '/' + fileName;

                }
                await _BusinessOwnerRegiServices.CreateAsync(obj);
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
            ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
            ViewBag.SectorList = _SectorRegistrationServices.GetAll().ToList();
            var model = _BusinessOwnerRegiServices.GetById(id);
            int stateidd = _CityRegistrationservices.GetById(model.cityid).stateid;
            int countryid = _StateRegistrationService.GetById(stateidd).countryid;

            int productidd = model.productid;
            int businessmasterid = _ProductMasterServices.GetById(productidd).businessid;
            int sectoridd = _BusinessRegistrationServieces.GetById(businessmasterid).sectorid;
            if (model == null)
            {
                return NotFound();
            }
            var model1 = new BusinessOwnerEditViewModel
            {
                id = model.id
                    ,
                name = model.name
                   //  , profilephoto = model.profilephoto
                    ,
                mobileno1 = model.mobileno1
                    ,
                mobileno2 = model.mobileno2
                    ,
                emailid1 = model.emailid1
                    ,
                emailid2 = model.emailid2
                    ,
                adharcardno = model.adharcardno
                   //, adharcardphoto = model.adharcardphoto
                    ,
                pancardno = model.pancardno
                   // ,   pancardphoto = model.pancardphoto
                    ,
                password = model.password
                    ,
                gender = model.gender
                    ,
                pinno = model.pinno
                    ,
                DOB = model.DOB
                    ,
                createddate = model.createddate
                    ,
                isdeleted = false
                    ,
                isactive = false
                    ,
                house = model.house
                    ,
                landmark = model.landmark
                    ,
                street = model.street
                ,countryid=countryid,
                stateid=stateidd
                    ,
                cityid = model.cityid
                    ,
                zipcode = model.zipcode
                    ,
                latitude = model.latitude
                    ,
                longitude = model.longitude
                    ,
                companyName = model.companyName
                    ,
                designation = model.designation
                    ,
                gstno = model.gstno
                    ,
                Website = model.Website
                    ,
                Discription = model.Discription
                    ,
                Regcertificate = model.Regcertificate
                    
                 ,sectorid=sectoridd,
                businessid=businessmasterid
                ,
                productid = model.productid
                    ,
                lic = model.lic



            };
            ViewBag.States = _StateRegistrationService.GetAllState(countryid);
            ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateidd);

            ViewBag.businessmasterList = _BusinessRegistrationServieces.GetAllBusiness(sectoridd);
            ViewBag.ProductList = _ProductMasterServices.GetAllProuct_SelectListItem(businessmasterid);
            //int productidd = model.productid;
            //int businessmasterid = _ProductMasterServices.GetById(productidd).businessid;
            //int sectoridd = _BusinessRegistrationServieces.GetById(businessmasterid).sectorid;
            return View(model1);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BusinessOwnerEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var affilatereg = _BusinessOwnerRegiServices.GetById(model.id);
                if (affilatereg == null)
                {
                    return NotFound();
                }
                 
                affilatereg.id = model.id;
                affilatereg.name = model.name;
               // affilatereg.profilephoto = model.profilephoto;
                affilatereg.mobileno1 = model.mobileno1;
                affilatereg.mobileno2 = model.mobileno2;
                affilatereg.emailid1 = model.emailid1;
                affilatereg.emailid2 = model.emailid2;
                affilatereg.adharcardno = model.adharcardno;
              //  affilatereg.adharcardphoto = model.id;
                affilatereg.pancardno = model.pancardno ;

                //affilatereg.pancardphoto = model.id;
                affilatereg.password = model.password ;
                affilatereg.gender = model.gender ;
                affilatereg.pinno = model.pinno ;
                affilatereg.DOB = model.DOB ;
               // affilatereg.createddate = model.id;
              //  affilatereg.isdeleted = model.id;
               // affilatereg.isactive = model.id;
                affilatereg.house = model.house ;
                affilatereg.landmark = model.landmark ;
                affilatereg.street = model.street ;

                affilatereg.cityid = model.cityid ;
                affilatereg.zipcode = model.zipcode ;
               // affilatereg.latitude = model.id;
                //affilatereg.longitude = model.id;
                affilatereg.companyName = model.companyName;
                affilatereg.designation = model.designation ;
                affilatereg.gstno = model.gstno ;
                affilatereg.Website = model.Website ;
                affilatereg.Discription = model.Discription ;
                affilatereg.Regcertificate = model.Regcertificate;

                affilatereg.productid = model.productid ;
                affilatereg.lic = model.lic ;

                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/BusinessOwner/profilephoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.profilephoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.pancardphoto != null && model.pancardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/BusinessOwner/pancardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.pancardphoto.FileName);
                    var extesion = Path.GetExtension(model.pancardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.pancardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.pancardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.adharcardphoto != null && model.adharcardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/BusinessOwner/adharcardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.adharcardphoto.FileName);
                    var extesion = Path.GetExtension(model.adharcardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.adharcardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.adharcardphoto = '/' + uploadDir + '/' + fileName;

                }
                await _BusinessOwnerRegiServices.UpdateAsync(affilatereg);
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
            await _BusinessOwnerRegiServices.Delete(id);
              return RedirectToAction(nameof(Index));

            
        }
      */
    }
}
