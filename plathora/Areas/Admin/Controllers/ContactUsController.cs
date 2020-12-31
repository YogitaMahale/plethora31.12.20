using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using plathora.Services;
using plathora.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class ContactUsController : Controller
    {
        private readonly IContactUsServices _contactUsServices;
        public ContactUsController(IContactUsServices contactUsServices)
        {
            _contactUsServices = contactUsServices;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        #region "API CALL"
        [HttpGet]
        public IActionResult GetALL()
        {

            
            var userList = _contactUsServices.GetAll().OrderByDescending(x=>x.id).ToList();
           
            return Json(new { data = userList });
            
        }

        #endregion
    }
}
