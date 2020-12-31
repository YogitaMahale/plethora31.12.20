using appFoodDelivery.Services;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy.Session;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Persistence;
using plathora.Services;
using plathora.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
//using System.Web.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class AdmindashboardController : Controller
    {
        private readonly ISP_Call _sP_Call;
        private readonly ApplicationDbContext _db;
        public AdmindashboardController(ISP_Call sP_Call, ApplicationDbContext db)
        {
            _sP_Call = sP_Call;
            _db = db;
        }
        // GET: /<controller>/

        public void LoginUserDetails()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (customerId == null)
            {
                //ViewBag.userName = "";
                //ViewBag.profilephoto = "/uploads/blaankCustomer.png";
                TempData["userName"] = "";
                TempData["profilephoto"] = "/uploads/blaankCustomer.png";

            }
            else
            {
                var objfromdb = _db.applicationUsers.FirstOrDefault(u => u.Id == customerId);
                if (objfromdb.name == null)
                {

                    TempData["userName"] = "";
                }
                else
                {

                    TempData["userName"] = objfromdb.name;
                }


                if (objfromdb.profilephoto == null)
                {
                    TempData["profilephoto"] = "/uploads/blaankCustomer.png";
                    //ViewBag.profilephoto = "/uploads/blaankCustomer.png";
                }
                else
                {

                    TempData["profilephoto"] = objfromdb.profilephoto;
                }

                
            }
            //TempData["userName"] = ViewBag.userName;
            //TempData["profilephoto"] = ViewBag.profilephoto;
            TempData.Keep("userName");
            TempData.Keep("profilephoto");
            //TempData.Keep();
        }
        public IActionResult Index()
        {
            LoginUserDetails();
            WebsiteDashboard obj = new WebsiteDashboard();
            var paramter = new DynamicParameters();          

            //paramter.Add("@from", l1);
            //paramter.Add("@to", l2);
            //paramter.Add("@affilateId", deliveryboyid);
            obj.objWebsiteDashboardcnt = _sP_Call.OneRecord<WebsiteDashboardSPViewModel>("WebsiteDashboardSP", null);


           
           IEnumerable<dashboardTableViewModel> barchartList = _sP_Call.List<dashboardTableViewModel>("dashboardBarchart", null);
            string Customermarkers = "[";
            //markers += "{";
            //markers += string.Format("'title': '{0}',", obj.objgetBusinessAllInfo.companyName);
            //markers += string.Format("'lat': '{0}',", obj.objgetBusinessAllInfo.latitude);
            //markers += string.Format("'lng': '{0}',", obj.objgetBusinessAllInfo.longitude);
            //markers += string.Format("'description': '{0}'", obj.objgetBusinessAllInfo.description);
            //markers += "}";
           
           
            string Affilatemarkers = "[";           
          
           

            string Labelsmarkers = "[";
           
          



            foreach (var item in barchartList)
            {

                Customermarkers += item.customer + ",";
                Affilatemarkers += item.affilate + ",";
                Labelsmarkers += "\"" + item.date + "\"" + ",";
            }
            string Customermarkers1 = Customermarkers.Remove(Customermarkers.Length - 1, 1);
            string Affilatemarkers1 = Affilatemarkers.Remove(Affilatemarkers.Length - 1, 1);
            string Labelsmarkers1 = Labelsmarkers.Remove(Labelsmarkers.Length - 1, 1);

            Labelsmarkers1 += "];";
            Affilatemarkers1 += "];";
            Customermarkers1 += "];";

            ViewBag.Affilatemarkers = Affilatemarkers1;
            ViewBag.Customermarkers = Customermarkers1;
            ViewBag.Labelsmarkers = Labelsmarkers1;
            return View(obj);
        }

        #region "API CALL"
        [HttpGet]
        public IActionResult GetALLCustomer()
        {
            try
            {
            var paramter = new DynamicParameters();

            //paramter.Add("@from", l1);
            //paramter.Add("@to", l2);
            //paramter.Add("@affilateId", deliveryboyid);
             
            IEnumerable<dashboardCustomerList> obj = _sP_Call.List<dashboardCustomerList>("TodayRegisterCustomer", null);


           
            return Json(new { data = obj.ToList() });
            }
            catch(Exception obj1)
            {
                string s = obj1.Message;
            }
            
            //var obj = _unitofWork.category.GetAll();
            return Json(new { data = "" });
        }
        public IActionResult GetALLAffilate()
        {
            try
            {
                var paramter = new DynamicParameters();

                //paramter.Add("@from", l1);
                //paramter.Add("@to", l2);
                //paramter.Add("@affilateId", deliveryboyid);

                IEnumerable<dashboardCustomerList> obj = _sP_Call.List<dashboardCustomerList>("TodayRegisterAffilate", null);



                return Json(new { data = obj.ToList() });
            }
            catch (Exception obj1)
            {
                string s = obj1.Message;
            }

            //var obj = _unitofWork.category.GetAll();
            return Json(new { data = "" });
        }
        //public ActionResult BarChart()
        //{
        //    var paramter = new DynamicParameters();

        //    //paramter.Add("@from", l1);
        //    //paramter.Add("@to", l2);
        //    //paramter.Add("@affilateId", deliveryboyid);

        //    IEnumerable<dashboardTable> obj = _sP_Call.List<dashboardTable>("dashboardBarchart", null);


        //    return Json(obj.ToList());
        //}
        #endregion
    }
}
