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
namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ModulemasterController : Controller
    {
        private readonly IModuleMasterServices _moduleMasterServices;

        public ModulemasterController(IModuleMasterServices moduleMasterServices)
        {
            _moduleMasterServices = moduleMasterServices;
        }
       
        public IActionResult Index()
        {
            var obj = _moduleMasterServices.GetAll().Select(x => new ModuleMasterIndexViewModel
            {
                 
                id = x.id,
                Name = x.Name,
                amount = x.amount,
                

            }).ToList();
            return View(obj);


        }
       
       [HttpGet]
       public IActionResult Create()
       {

           var model = new ModuleMasterCreateViewModel();
           return View(model);
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Create(ModuleMasterCreateViewModel model)
       {

           if (ModelState.IsValid)
           {
               var objcountry = new ModuleMaster
               {
                   id = model.id,
                   Name = model.Name,
                   amount = model.amount,
                 
                   isdeleted = false,
                   isactive = false
               };

               await _moduleMasterServices.CreateAsync(objcountry);
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

          var obj = _moduleMasterServices.GetById(id);
          if (obj == null)
          {
              return NotFound();
          }
          var model = new ModuleMasterEditViewModel
          {
              id = obj.id,
              Name = obj.Name,
              amount = obj.amount,
              isdeleted = obj.isdeleted,
              isactive = obj.isactive,

          };
          return View(model);


      }
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(ModuleMasterEditViewModel model)
      {
          if (ModelState.IsValid)
          {
              var obj = _moduleMasterServices.GetById(model.id);
              if (obj == null)
              {
                  return NotFound();
              }
                obj.id = model.id;
                obj.Name = model.Name;

                obj.amount = model.amount;
                obj.isdeleted = model.isdeleted;
                obj.isactive = model.isactive;

              await _moduleMasterServices.UpdateAsync(obj);
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
          await _moduleMasterServices.Delete(id);
          return RedirectToAction(nameof(Index));
      }
       
    }
}
