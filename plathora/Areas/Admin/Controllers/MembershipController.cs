using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Services;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MembershipController : Controller
    {
        private readonly IMembershipServices _MembershipServices;
        public MembershipController(IMembershipServices MembershipServices)
        {
            _MembershipServices = MembershipServices;

        }

        public IActionResult Index()
        {
            var countrydetails = _MembershipServices.GetAll().Select(x => new MembershipIndexViewModel
            {
                id = x.id,
                membershipName = x.membershipName,
                gst=x.gst ,
                amount=x.amount,
                period=x.period

            }).ToList();
            return View(countrydetails);


        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new MembershipCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MembershipCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var objcountry = new Membership
                {
                    id = model.id,
                    membershipName = model.membershipName,
                  gst=model.gst,
                    isdeleted = false,
                    isactive = false,
                    amount=model.amount,
                    period=model.period
                };

                await _MembershipServices.CreateAsync(objcountry);
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
            var objcountry = _MembershipServices.GetById(id);
            if (objcountry == null)
            {
                return NotFound();
            }
            var model = new MembershipEditViewModel
            {
                id = objcountry.id,
                membershipName  = objcountry.membershipName,
                gst = objcountry.gst,
                period=objcountry.period,
                amount=objcountry.amount

            };
            return View(model);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MembershipEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objcountry = _MembershipServices.GetById(model.id);
                if (objcountry == null)
                {
                    return NotFound();
                }
                objcountry.id = model.id;
                objcountry.membershipName = model.membershipName;
                objcountry.gst = model.gst;
                objcountry.amount = model.amount;
                objcountry.period  = model.period;


                await _MembershipServices.UpdateAsync(objcountry);
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
            await _MembershipServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
