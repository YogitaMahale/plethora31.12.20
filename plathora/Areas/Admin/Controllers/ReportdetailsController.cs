using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Models;
using plathora.pagination;
using plathora.Persistence;
using plathora.Services;
using plathora.Utility;
namespace plathora.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ReportdetailsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ISP_Call _sP_Call;
        public ReportdetailsController(  ApplicationDbContext db, ISP_Call sP_Call)
        {
            _sP_Call = sP_Call;
            _db = db;

        }

        public IEnumerable<SelectListItem> GetAllAffilate()
        {
            var parameter = new DynamicParameters();
           // parameter.Add("@name", name);

            var obj = _sP_Call.List<AffilateListViewModel>("AffilateList", parameter);

            // IEnumerable<SelectListItem> myGenericEnumerable = (IEnumerable<SelectListItem>)obj;

            IEnumerable<SelectListItem> listt= obj.Select(emp => new SelectListItem()
            {
                Text = emp.name,
                Value = emp.Id.ToString()
            });
          
             
            return listt;
        }
        [HttpGet]
        public async Task<IActionResult> collectionReport(int? PageNumber, string from1, string to1, string deliveryboyid)
        {




           // List<SelectList> cl = new List<SelectList>();
            // cl = (from c in _auc.country select c).ToList();

            //List<SelectListItem> mySkills = new List<SelectListItem>() {

            //ViewData["MySkills"] = mySkills;
           // IEnumerable<AffilateListViewModel> obj = GetAllAffilate();
           ViewData["affilatelist"]  = GetAllAffilate();
            //ViewBag.affilatelist  = GetAllAffilate(); 

            ViewBag.deliveryboyid1 = deliveryboyid;


            //   DateTime dt = DateTime.ParseExact(DateTime.Now.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            string s = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
            if (from1==null||from1=="")
            {
                //from1 = "01/01/2020";
                from1 = s;
            }
            if (to1 == null || to1 == "")
            {
                to1 = s;
            }
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            //ViewBag.status1 = status;



            var paramter = new DynamicParameters();

            DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            paramter.Add("@from", l1);
            paramter.Add("@to", l2);
            paramter.Add("@affilateId", deliveryboyid);
            var orderheaderList1 = _sP_Call.List<collectionreport_affilateViewModel>("collectionReport", paramter);

            //  return View(orderheaderList1.ToList());
            int PageSize = 10;

             
              
            return View(collectionreport_affilatePagination<collectionreport_affilateViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));


        }

        [HttpPost]
        public async Task<IActionResult> collectionReport(int? PageNumber, string from1, string to1, string search, string ExcelFileDownload, string deliveryboyid)
        {


            //IEnumerable<SelectListItem> obj = GetAllAffilate();
            // ViewData["deliveryboylist"] = obj;
            // ViewBag.affilatelist = obj;
            // ViewBag.affilatelist = GetAllAffilate();
            ViewData["affilatelist"] = GetAllAffilate();
            //---------------------------------------------
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;

            ViewBag.deliveryboyid1 = deliveryboyid;


            if (search != null)
            {
                
                try
                {
                var paramter = new DynamicParameters();
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@affilateId", deliveryboyid);
                var orderheaderList1 = _sP_Call.List<collectionreport_affilateViewModel>("collectionReport", paramter);
                //  return View(orderheaderList1.ToList());
                int PageSize = 10;
                    return View(collectionreport_affilatePagination<collectionreport_affilateViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

                }
                catch (Exception obj)
                {
                    string msg = obj.Message;
                }
              
                
            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();
                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@affilateId", deliveryboyid);
                var orderheaderList1 = _sP_Call.List<collectionreport_affilateViewModel>("collectionReport", paramter);



                string Affilatename = _db.applicationUsers.Where(x=>x.Id==deliveryboyid).FirstOrDefault().name;


                var builder = new StringBuilder();
                builder.AppendLine(" Name,Phone,Date,Package,Package Amount, Commi(%), GST(%), GST Amount, Plethora ,  Commission, TDS,  Total");


                
                      decimal tot_amt = 0;

                foreach (var item in orderheaderList1)
                {
                    tot_amt += item.PaymentAmount;

                    builder.AppendLine($" {item.name }, {item.PhoneNumber }, {item.createddate }, {item.AffilatePackageName },  {item.AffilatePackageAmount }, {item.commissionper }, {item.gst },{item.gstAmount }, {item.plethoraamt }, {item.commissionAmount },{item.tds }, {item.PaymentAmount }");
                }
                builder.AppendLine($" {"Total :"},{tot_amt }");
                string namee = Affilatename + "_AffilateReport.csv";
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", namee);
                 


             //< td > @item.name </ td >
             //                       < td > @item.PhoneNumber </ td >
             //                       < td > @item.createddate </ td >
             //                       < td > @item.AffilatePackageName </ td >
             //                       < td > @item.AffilatePackageAmount </ td >
             //                       < td > @item.commissionper </ td >
             //                       < td > @item.gst </ td >
             //                       < td > @item.gstAmount </ td >
             //                       < td > @item.plethoraamt </ td >
             //                       < td > @item.commissionAmount </ td >
             //                       < td > @item.tds </ td >
             //                       < td > @item.PaymentAmount </ td >
            }


            else
            {
                return View();
            }


            return View();
        }


        //--------advertise---------------------------------------

        [HttpGet]
        public async Task<IActionResult> AdvertiseReport(int? PageNumber, string from1, string to1, string deliveryboyid)
        {




            // List<SelectList> cl = new List<SelectList>();
            // cl = (from c in _auc.country select c).ToList();

            //List<SelectListItem> mySkills = new List<SelectListItem>() {

            //ViewData["MySkills"] = mySkills;
            // IEnumerable<AffilateListViewModel> obj = GetAllAffilate();
            //  ViewData["deliveryboylist"] = obj;
            //  ViewBag.affilatelist = GetAllAffilate();
            ViewData["affilatelist"] = GetAllAffilate();
            ViewBag.deliveryboyid1 = deliveryboyid;
            string s = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
            if (from1 == null || from1 == "")
            {
                from1 = s;
            }
            if (to1 == null || to1 == "")
            {
                to1 = s;
            }
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            //ViewBag.status1 = status;



            var paramter = new DynamicParameters();

            DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            paramter.Add("@from", l1);
            paramter.Add("@to", l2);
            paramter.Add("@affilateId", deliveryboyid);
            var orderheaderList1 = _sP_Call.List<AdvertisecollectionReportSPModel>("AdvertisecollectionReportSP", paramter);

            //  return View(orderheaderList1.ToList());
            int PageSize = 10;



            return View(collectionreport_affilatePagination<AdvertisecollectionReportSPModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));


        }

        [HttpPost]
        public async Task<IActionResult> AdvertiseReport(int? PageNumber, string from1, string to1, string search, string ExcelFileDownload, string deliveryboyid)
        {


            //IEnumerable<SelectListItem> obj = GetAllAffilate();
            // ViewData["deliveryboylist"] = obj;
            // ViewBag.affilatelist = obj;
            // ViewBag.affilatelist = GetAllAffilate();
            ViewData["affilatelist"] = GetAllAffilate();
            //---------------------------------------------
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;

            ViewBag.deliveryboyid1 = deliveryboyid;


            if (search != null)
            {

                var paramter = new DynamicParameters();

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@affilateId", deliveryboyid);
                var orderheaderList1 = _sP_Call.List<AdvertisecollectionReportSPModel>("AdvertisecollectionReportSP", paramter);

                //  return View(orderheaderList1.ToList());
                int PageSize = 10;

                return View(collectionreport_affilatePagination<AdvertisecollectionReportSPModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@affilateId", deliveryboyid);
                var orderheaderList1 = _sP_Call.List<AdvertisecollectionReportSPModel>("AdvertisecollectionReportSP", paramter);

                string Affilatename = _db.applicationUsers.Where(x => x.Id == deliveryboyid).FirstOrDefault().name;



                var builder = new StringBuilder();
                builder.AppendLine("    Name , Phone ,Title ,Date , Package ,  Package Amount ,  Commi(%) ,  GST(%) , GST Amount , Plethora  , Commission , TDS ,  Total ");
                decimal tot_amt = 0;

                foreach (var item in orderheaderList1)
                {
                    tot_amt += item.PaymentAmount;

                    builder.AppendLine($"{@item.name}, {@item.PhoneNumber}, {@item.title}, {@item.createddate}, {@item.pkgname}, {@item.PackageAmount}, {@item.commissionper}, {@item.gst},{@item.gstAmount},  {@item.plethoraamt },{@item.commissionAmount}, {@item.tds},{@item.PaymentAmount}");
                }
                builder.AppendLine($" {"Total :"},{tot_amt }");
                string namee = Affilatename + "_advertiseReport.csv";
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", namee);
                
            }


            else
            {
                return View();
            }


            return View();
        }
        //-----------------------------------------------

        [HttpGet]
        public async Task<IActionResult> businessOwnerReport(int? PageNumber, string from1, string to1, string deliveryboyid)
        {




            // List<SelectList> cl = new List<SelectList>();
            // cl = (from c in _auc.country select c).ToList();

            //List<SelectListItem> mySkills = new List<SelectListItem>() {

            //ViewData["MySkills"] = mySkills;
            // IEnumerable<AffilateListViewModel> obj = GetAllAffilate();
            //  ViewData["deliveryboylist"] = obj;
            //ViewBag.affilatelist = GetAllAffilate();
            ViewData["affilatelist"] = GetAllAffilate();
            ViewBag.deliveryboyid1 = deliveryboyid;
            string s = DateTime.Now.ToString("dd/MM/yyyy").Replace('-', '/');
            if (from1 == null || from1 == "")
            {
                from1 = s;
            }
            if (to1 == null || to1 == "")
            {
                to1 = s;
            }
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;
            //ViewBag.status1 = status;



            var paramter = new DynamicParameters();

            DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


            paramter.Add("@from", l1);
            paramter.Add("@to", l2);
            paramter.Add("@affilateId", deliveryboyid);
            var orderheaderList1 = _sP_Call.List<BusinessownercollectionReportSPModel>("BusinessownercollectionReportSP", paramter);

            //  return View(orderheaderList1.ToList());
            int PageSize = 10;



            return View(collectionreport_affilatePagination<BusinessownercollectionReportSPModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));


        }

        [HttpPost]
        public async Task<IActionResult> businessOwnerReport(int? PageNumber, string from1, string to1, string search, string ExcelFileDownload, string deliveryboyid)
        {


            //IEnumerable<SelectListItem> obj = GetAllAffilate();
            // ViewData["deliveryboylist"] = obj;
            // ViewBag.affilatelist = obj;
            // ViewBag.affilatelist = GetAllAffilate();
            ViewData["affilatelist"] = GetAllAffilate();
            //---------------------------------------------
            ViewBag.from1 = from1;
            ViewBag.to1 = to1;

            ViewBag.deliveryboyid1 = deliveryboyid;


            if (search != null)
            {
                try
                {
               var paramter = new DynamicParameters();

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@affilateId", deliveryboyid);
                var orderheaderList1 = _sP_Call.List<BusinessownercollectionReportSPModel>("BusinessownercollectionReportSP", paramter);

                //  return View(orderheaderList1.ToList());
                int PageSize = 10;

                return View(collectionreport_affilatePagination<BusinessownercollectionReportSPModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));

                }
                catch(Exception obj)
                {
                    string msg = obj.Message;
                }

              
            }
            else if (ExcelFileDownload != null)
            {

                var paramter = new DynamicParameters();

                DateTime l1 = DateTime.ParseExact(from1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime l2 = DateTime.ParseExact(to1, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                paramter.Add("@from", l1);
                paramter.Add("@to", l2);
                paramter.Add("@affilateId", deliveryboyid);
                var orderheaderList1 = _sP_Call.List<BusinessownercollectionReportSPModel>("BusinessownercollectionReportSP", paramter);

                string Affilatename = _db.applicationUsers.Where(x => x.Id == deliveryboyid).FirstOrDefault().name;


                var builder = new StringBuilder();
                builder.AppendLine("Name, Phone, Date, Business Package,  Package Amount,  Commi(%),   GST(%), GST Amount, Plethora ,  Commission, TDS,    Total");
                decimal tot_amt = 0;

                foreach (var item in orderheaderList1)
                {
                    tot_amt += item.PaymentAmount;

                    builder.AppendLine($"  {@item.name}, {@item.PhoneNumber}, {@item.createddate}, {@item.pkgname},{@item.PackageAmount}, {@item.commissionper},  {@item.gst},{item.gstAmount},{@item.plethoraamt }, {@item.commissionAmount},  {@item.tds}, {@item.PaymentAmount}");
                }
                builder.AppendLine($" {"Total :"},{tot_amt }");
                string namee = Affilatename + "_BusinessDetails.csv";
                return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", namee);
                 
            }


            else
            {
                return View();
            }


            return View();
        }


        //-----------------------------------------------

        [HttpGet]
        public async Task<IActionResult> Commission(int? PageNumber)
        {

 
            var paramter = new DynamicParameters();

            
            ///paramter.Add("@from", l1);
             
            var orderheaderList1 = _sP_Call.List<commissionShowViewModel>("commiossionReportSP", null);

            //  return View(orderheaderList1.ToList());
            int PageSize = 10;



            return View(collectionreport_affilatePagination<commissionShowViewModel>.Create(orderheaderList1.ToList(), PageNumber ?? 1, PageSize));


        }

    }
}
