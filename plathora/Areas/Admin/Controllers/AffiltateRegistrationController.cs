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
using System.Security.Cryptography.X509Certificates;
using System.Web.Http.Validation;

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AffiltateRegistrationController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAffiltateRegistrationService _AffiltateRegistrationService;
        private readonly IMembershipServices _MembershipServices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly IAffilatePackageServices _AffilatePackageServices;
        public AffiltateRegistrationController(IMembershipServices MembershipServices, ICityRegistrationservices CityRegistrationservices,IStateRegistrationService StateRegistrationService,ICountryRegistrationservices CountryRegistrationservices, IAffiltateRegistrationService AffiltateRegistrationService, IWebHostEnvironment hostingEnvironment, IAffilatePackageServices AffilatePackageServices)
        {
            _AffiltateRegistrationService = AffiltateRegistrationService;
            _hostingEnvironment = hostingEnvironment;
            _CountryRegistrationservices = CountryRegistrationservices;
            _CityRegistrationservices = CityRegistrationservices;
            _StateRegistrationService = StateRegistrationService;
            _MembershipServices = MembershipServices;
            _AffilatePackageServices = AffilatePackageServices;
        }

        public IActionResult Index(int? PageNumber)
        {
            var affilatemaster = _AffiltateRegistrationService.GetAll().Select(x => new AffiltateRegistrationIndexViewModel
            {
                id = x.id,
                name = x.name,
                profilephoto = x.profilephoto,
                mobileno1 = x.mobileno1,
                mobileno2 = x.mobileno2,
                emailid1 = x.emailid1,
                DOB = x.DOB,
                createddate = x.createddate,
                isactive=x.isactive
            }).ToList();
           // return View(affilatemaster);
            int PageSize = 4;
            return View(AffilateRegPagination<AffiltateRegistrationIndexViewModel>.Create(affilatemaster, PageNumber ?? 1, PageSize));
        }
        
        public JsonResult getpackageamtbymembershipid(int membershipid)
        {

            AffilatePackage obj = _AffilatePackageServices.GetAll().Where(x => x.membershipid == membershipid&&x.isdeleted==false).FirstOrDefault();
            
            return Json(obj);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Countries = _CountryRegistrationservices.GetAll().ToList();
            ViewBag.membershiplist = _MembershipServices.GetAll().ToList();
            var model = new AffiltateRegistrationCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AffiltateRegistrationCreateViewModel model)
        {
            // id, name, profilephoto, mobileno1, mobileno2, emailid1, emailid2
            //, adharcardno, adharcardphoto, pancardno, pancardphoto, password
            //, gender, DOB, createddate
            if (ModelState.IsValid)
            {


                var objAffiltateRegistration = new AffiltateRegistration
                {
                    id = model.id,

                    name = model.name,
                    //profilephoto,
                    mobileno1 = model.mobileno1,
                    mobileno2 = model.mobileno2,
                    emailid1 = model.emailid1,
                    emailid2 = model.emailid2,
                    adharcardno = model.adharcardno,
                    //adharcardphoto,
                    pancardno = model.pancardno,
                    // pancardphoto,
                    password = model.password,
                    gender = model.gender,
                    DOB = model.DOB,
                    createddate = model.createddate,
                   
                    isdeleted=false,
                    isactive = false,
                    house = model.house,
                    landmark = model.landmark ,
                    street = model.street ,
                    cityid = model.cityid ,
                    zipcode = model.zipcode ,

                    companyName = model.companyName ,
                    designation = model.designation,
                    gstno = model.gstno ,
                    Website = model.Website ,
                    bankname = model.bankname ,
                    accountname = model.accountname ,
                    accountno = model.accountno,
                    ifsccode = model.ifsccode ,
                    branch = model.branch ,

                    Membershipid = model.Membershipid,
                    amount = model.amount ,
                    registerbyAffilateID=0
                };

                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/Affiltate/profilephoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.profilephoto.FileName);
                    var extesion = Path.GetExtension(model.profilephoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                   await  model.profilephoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    objAffiltateRegistration.profilephoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.pancardphoto != null && model.pancardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/Affiltate/pancardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.pancardphoto.FileName);
                    var extesion = Path.GetExtension(model.pancardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.pancardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    objAffiltateRegistration.pancardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.adharcardphoto != null && model.adharcardphoto.Length > 0)
                {
                    var uploadDir = @"uploads/Affiltate/adharcardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.adharcardphoto.FileName);
                    var extesion = Path.GetExtension(model.adharcardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.adharcardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    objAffiltateRegistration.adharcardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.passbookphoto != null && model.passbookphoto.Length > 0)
                {
                    var uploadDir = @"uploads/Affiltate/passbookphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.passbookphoto.FileName);
                    var extesion = Path.GetExtension(model.passbookphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.passbookphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    objAffiltateRegistration.passbookphoto = '/' + uploadDir + '/' + fileName;

                }
                await _AffiltateRegistrationService.CreateAsync(objAffiltateRegistration);
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
            var model = _AffiltateRegistrationService.GetById(id);
            ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
            ViewBag.membershiplist = _MembershipServices.GetAll().ToList();
            int stateid = _CityRegistrationservices.GetById(model.cityid).stateid;
            int countryid = _StateRegistrationService.GetById(stateid).countryid;
            if (model == null)
            {
                return NotFound();
            }
            var obj = new AffiltateRegistrationEditViewModel
            {
                id = model.id,

                name = model.name,
                //profilephoto,
                mobileno1 = model.mobileno1,
                mobileno2 = model.mobileno2,
                emailid1 = model.emailid1,
                emailid2 = model.emailid2,
                adharcardno = model.adharcardno,
                //adharcardphoto,
                pancardno = model.pancardno,
                // pancardphoto,
                password = model.password,
                gender = model.gender,
                DOB = model.DOB,

                house = model.house,
                landmark = model.landmark,
                street = model.street,
                countryid = countryid,
                stateid= stateid,
                cityid = model.cityid,
                zipcode = model.zipcode,

                companyName = model.companyName,
                designation = model.designation,
                gstno = model.gstno,
                Website = model.Website,
                bankname = model.bankname,
                accountname = model.accountname,
                accountno = model.accountno,
                ifsccode = model.ifsccode,
                branch = model.branch,

                Membershipid = model.Membershipid,
                amount = model.amount
            };
            ViewBag.States = _StateRegistrationService.GetAllState(countryid);
            ViewBag.Cities = _CityRegistrationservices.GetAllCity(stateid);
            return View(obj);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AffiltateRegistrationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var affilatereg = _AffiltateRegistrationService.GetById(model.id);
                if (affilatereg == null)
                {
                    return NotFound();
                }
              
                    

                affilatereg.id = model.id;
                affilatereg.name = model.name;
                //profilephoto,
                affilatereg.mobileno1 = model.mobileno1;
                affilatereg.mobileno2 = model.mobileno2;
                affilatereg.emailid1 = model.emailid1;
                affilatereg.emailid2 = model.emailid2;
                affilatereg.adharcardno = model.adharcardno;
                //adharcardphoto,
                affilatereg.pancardno = model.pancardno;
                // pancardphoto,
                affilatereg.password = model.password;
                affilatereg.gender = model.gender;
                affilatereg.DOB = model.DOB;
                //   affilatereg.createddate = model.createddate;
                affilatereg.house = model.house;
                affilatereg.landmark = model.landmark;
                affilatereg.street = model.street;
                affilatereg.cityid = model.cityid;
                affilatereg.companyName = model.companyName;
                affilatereg.designation = model.designation;
                affilatereg.gstno = model.gstno;
                affilatereg.Website = model.Website;
                affilatereg.bankname = model.bankname;
                affilatereg.accountname = model.accountname;

                affilatereg.accountno = model.accountno;
                affilatereg.ifsccode = model.ifsccode;
                affilatereg.branch = model.branch;
                affilatereg.Membershipid = model.Membershipid;
                affilatereg.amount = model.amount;
               
               
               

                if (model.profilephoto != null && model.profilephoto.Length > 0)
                {
                    var uploadDir = @"uploads/Affiltate/profilephoto";
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
                    var uploadDir = @"uploads/Affiltate/pancardphoto";
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
                    var uploadDir = @"uploads/Affiltate/adharcardphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.adharcardphoto.FileName);
                    var extesion = Path.GetExtension(model.adharcardphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.adharcardphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.adharcardphoto = '/' + uploadDir + '/' + fileName;

                }
                if (model.passbookphoto != null && model.passbookphoto.Length > 0)
                {
                    var uploadDir = @"uploads/Affiltate/passbookphoto";
                    var fileName = Path.GetFileNameWithoutExtension(model.passbookphoto.FileName);
                    var extesion = Path.GetExtension(model.passbookphoto.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extesion;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.passbookphoto.CopyToAsync(new FileStream(path, FileMode.Create));
                    affilatereg.passbookphoto = '/' + uploadDir + '/' + fileName;

                }
                await _AffiltateRegistrationService.UpdateAsync(affilatereg);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _AffiltateRegistrationService.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            AffiltateRegistrationDetailsViewModel obj = new AffiltateRegistrationDetailsViewModel()
            {
                id = model.id,
                name = model.name,
                profilephoto = model.profilephoto,
                mobileno1 = model.mobileno1,
                mobileno2 = model.mobileno2,
                emailid1 = model.emailid1,
                emailid2 = model.emailid2,
                adharcardno = model.adharcardno,
                adharcardphoto = model.adharcardphoto,
                pancardno = model.pancardno,
                pancardphoto = model.pancardphoto,
                password = model.password,
                gender = model.gender,
                DOB = model.DOB,
                createddate = model.createddate

            };
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _AffiltateRegistrationService.GetById(id);
            if (emp == null)
            {
                return NotFound();

            }
            AffiltateRegistrationDeleteViewModel model = new AffiltateRegistrationDeleteViewModel()
            {
                id = emp.id,
                name  = emp.name 
            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AffiltateRegistrationDeleteViewModel model)
        {
            await _AffiltateRegistrationService.Delete(model.id);
            return RedirectToAction(nameof(Index));
        }
    }
}
