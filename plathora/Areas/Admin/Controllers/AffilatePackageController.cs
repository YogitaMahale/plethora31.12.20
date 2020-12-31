using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using plathora.Entity;
using plathora.Models;
using plathora.Services;

using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AffilatePackageController : Controller
    {
        private readonly IMembershipServices _MembershipServices;
        private readonly IcommissionServices _commissionServices;
        private readonly IAffilatePackageServices _AffilatePackageServices;
        public AffilatePackageController(IMembershipServices MembershipServices, IcommissionServices commissionServices, IAffilatePackageServices AffilatePackageServices)
        {

            _MembershipServices = MembershipServices;
            _commissionServices = commissionServices;
            _AffilatePackageServices = AffilatePackageServices;

        }


        public IActionResult index()
        {
            var citydetails = _AffilatePackageServices.GetAll().Select(x => new AffilatePackageIndexModel
            {


                id = x.id,
                membershipid  = x.membershipid,
                commissionid  = x.commissionid,
                amount  = x.amount,
                Description  = x.Description,
                Membership = _MembershipServices.GetById(x.membershipid),
                commission  = _commissionServices .GetById(x.commissionid),
                gst=x.gst,
                affilateamt=x.affilateamt,
                plethoraamt=x.plethoraamt

            }).ToList();
            return View(citydetails);


        }

        //public JsonResult getstatebyid(int id)
        //{

        //    IList<StateRegistration> obj = _StateRegistrationService.GetAll().Where(x => x.countryid == id).ToList();
        //    obj.Insert(0, new StateRegistration { id = 0, StateName = "select", isactive = false, isdeleted = false });
        //    return Json(new SelectList(obj, "id", "StateName"));
        //}

        //public IActionResult GetStates(string countryid)
        //{
        //    ViewBag.Countries = _CountryRegistrationservices.GetAllCountry();
        //    ViewBag.States = _StateRegistrationService.GetAllState(Convert.ToInt16(countryid));
        //    return View("Create");
        //}
        [HttpGet]
        public IActionResult Create()
        {
            
            ViewBag.MembershipList = _MembershipServices .GetAll().ToList();
            ViewBag.CommissionList = _commissionServices .GetAll().ToList();
            //  ViewBag.StateEnabled = false;
            var model = new AffilatePackageCreateModel ();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AffilatePackageCreateModel model)
        {

            if (ModelState.IsValid)
            {
                var obj = _AffilatePackageServices.GetAll().Where(x => x.membershipid == model.membershipid && x.isdeleted == false).FirstOrDefault();
                if(obj!=null)
                {
                    ModelState.AddModelError("CustomError", "This Package Name Already Added");
                    ViewBag.MembershipList = _MembershipServices.GetAll().ToList();
                    ViewBag.CommissionList = _commissionServices.GetAll().ToList();
                    //  ViewBag.StateEnabled = false;

                    return View(model);

                    
                }
                else
                {
                    var objcountry = new AffilatePackage
                    {

                        id = model.id,
                        membershipid = model.membershipid,
                        commissionid = model.commissionid,
                        amount = model.amount,
                        Description = model.Description,
                        isdeleted = false,
                        isactive = false,
                        gst=model.gst,
                        affilateamt=model.affilateamt,
                        plethoraamt=model.plethoraamt
                    };

                    await _AffilatePackageServices.CreateAsync(objcountry);
                    return RedirectToAction(nameof(Index));


                }

            }
            else
            {
                ModelState.AddModelError("CustomError", "This Package Name Already Added");
                ViewBag.MembershipList = _MembershipServices.GetAll().ToList();
                ViewBag.CommissionList = _commissionServices.GetAll().ToList();
                //  ViewBag.StateEnabled = false;

                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.MembershipList = _MembershipServices.GetAll().ToList();
            ViewBag.CommissionList = _commissionServices.GetAll().ToList();



            var objcountry = _AffilatePackageServices.getbyid(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new AffilatePackageEditModel
            {
                id = objcountry.id
                ,
                membershipid = objcountry.membershipid
                ,
                commissionid = objcountry.commissionid
                 ,
                amount  = objcountry.amount
                 ,
                Description  = objcountry.Description,
                gst=objcountry.gst,
                plethoraamt = objcountry.plethoraamt,
                affilateamt = objcountry.affilateamt
            };
            
            return View(model);


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AffilatePackageEditModel model)
        {
            if (ModelState.IsValid)
            {

                var obj = _AffilatePackageServices.GetAll().Where(x => x.membershipid == model.membershipid && x.isdeleted == false&&x.id!=model.id).FirstOrDefault();
                if (obj == null)
                {


                    var objcountry = _AffilatePackageServices.getbyid(model.id);
                    if (objcountry == null)
                    {
                        return NotFound();
                    }
                    objcountry.id = model.id;
                    objcountry.membershipid = model.membershipid;
                    objcountry.commissionid = model.commissionid;
                    objcountry.amount = model.amount;
                    objcountry.Description = model.Description;
                    objcountry.gst = model.gst;

                    objcountry.plethoraamt = model.plethoraamt;
                    objcountry.affilateamt = model.affilateamt;

                    await _AffilatePackageServices.UpdateAsync(objcountry);
                    return RedirectToAction(nameof(index));
                }
                else
                {
                    ModelState.AddModelError("CustomError", "This Package Name Already Added");
                    ViewBag.MembershipList = _MembershipServices.GetAll().ToList();
                    ViewBag.CommissionList = _commissionServices.GetAll().ToList();
                    //  ViewBag.StateEnabled = false;

                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _AffilatePackageServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
