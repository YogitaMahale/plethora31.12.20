using Dapper;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Persistence;
using plathora.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using plathora.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using SectorRegistrationIndexViewModel = plathora.Models.SectorRegistrationIndexViewModel;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace plathora.Controllers
{
    [Area("Admin")]
    // [Authorize(Roles = SD.Role_Admin)]
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        private readonly ISP_Call _sP_Call;
        private IConfiguration Configuration;
        private ISectorRegistrationServices _SectorRegistrationServices;
        private IBusinessRegistrationServieces _BusinessRegistrationServieces;
        private IProductMasterServices _productMasterServices;
        private IAboutUsServices _aboutUsServices;
        private IContactUsServices _ContactUsServices;
        private IbusinessratingsServices _businessratingsServices;
        private IBusinessOwnerRegiServices _businessOwnerRegiServices;
        private INewsServices _newsServices;
        private readonly ApplicationDbContext _db;
        private readonly Iratingsservices _ratingsservices;
       private readonly UserManager<IdentityUser> _usermanager;
        private readonly ICityRegistrationservices _cityRegistrationservices;
        public HomeController(ILogger<HomeController> logger, ISP_Call sP_Call, IConfiguration _Configuration, ISectorRegistrationServices SectorRegistrationServices, IBusinessRegistrationServieces BusinessRegistrationServieces, IProductMasterServices productMasterServices, IAboutUsServices aboutUsServices, IContactUsServices ContactUsServices, IbusinessratingsServices businessratingsServices, IBusinessOwnerRegiServices businessOwnerRegiServices, INewsServices newsServices, ApplicationDbContext db, Iratingsservices ratingsservices, UserManager<IdentityUser> usermanager, ICityRegistrationservices cityRegistrationservices)//, UserManager<ApplicationUser> usermanager
        {
            //_logger = logger;
            _sP_Call = sP_Call;
            Configuration = _Configuration;
            _SectorRegistrationServices = SectorRegistrationServices;
            _BusinessRegistrationServieces = BusinessRegistrationServieces;
            _productMasterServices = productMasterServices;
            _aboutUsServices = aboutUsServices;
            _ContactUsServices = ContactUsServices;
            _businessratingsServices = businessratingsServices;
            _businessOwnerRegiServices = businessOwnerRegiServices;
            _newsServices = newsServices;
           _usermanager = usermanager;
             _db = db;
            _ratingsservices = ratingsservices;
            _cityRegistrationservices = cityRegistrationservices;
        }
      
        public void LoginUserDetails()
        {
            var customerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (customerId == null)
            {
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
                }
                else
                {

                    TempData["profilephoto"] = objfromdb.profilephoto;
                }
            }
            TempData.Keep("userName");
            TempData.Keep("profilephoto");
        }
        [HttpGet]
        public IActionResult Index()
        {
            LoginUserDetails();
            try
            {

               




                IEnumerable<SelectListItem> cities = _cityRegistrationservices.GetAllCities();
                ViewData["cities"] = cities;
                frontwebsiteModel objmodel = new frontwebsiteModel();
                var parameter = new DynamicParameters();
                objmodel.objBusinessDetails = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);
                objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().Take(12).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                {
                    id = x.id,
                    name = x.name,
                    img = x.img,
                    photo = x.photo

                }).ToList();

                objmodel.objNews = _newsServices.GetAll().Where(x => x.isdeleted == false).OrderByDescending(x => x.id).Select(x => new NewIndexViewModel
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    description = x.description,
                    isdeleted = x.isdeleted,
                    isactive = x.isactive,
                    date1 = x.date1,
                    createddate = x.createddate

                }).ToList();
                return View(objmodel);
            }
            catch (Exception obj)
            {
            }
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult Index1(string txtsearch,int cityid)
        {
            try
            {
                IEnumerable<SelectListItem> cities = _cityRegistrationservices.GetAllCities();
                ViewData["cities"] = cities;
                //ViewBag.cities = _cityRegistrationservices.GetAll().Where(x => x.isdeleted == false).ToList();
                ViewBag.search = txtsearch;
                frontwebsiteModel objmodel = new frontwebsiteModel();
                //  ViewBag.search = txtsearch;                var parameter = new DynamicParameters();
                //IEnumerable<selectallBusinessDetailsDtos> obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);
                objmodel.objBusinessDetails = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);
                //if (txtsearch == null || txtsearch.Trim() == "")
                //{
                //    objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().OrderByDescending(x => x.id).Where(x => x.isdeleted == false).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                //    {
                //        id = x.id,
                //        name = x.name,
                //        img = x.img,
                //        photo = x.photo

                //    }).ToList();
                //}
                //else
                //{
                //    objmodel.objSectorRegistration = _SectorRegistrationServices.GetAll().Where(x => x.name.Contains(txtsearch) && x.isdeleted == false).Select(x => new plathora.Models.SectorRegistrationIndexViewModel
                //    {
                //        id = x.id,
                //        name = x.name,
                //        img = x.img,
                //        photo = x.photo

                //    }).ToList();
                //}
                objmodel.objNews = _newsServices.GetAll().Where(x => x.isdeleted == false).Select(x => new NewIndexViewModel
                {
                    id = x.id,
                    title = x.title,
                    img = x.img,
                    description = x.description,
                    isdeleted = x.isdeleted,
                    isactive = x.isactive,
                    date1 = x.date1,
                    createddate = x.createddate

                });
                //------------------------------------------------------------------------------------
                DataSet ds = new DataSet();

                string connString = this.Configuration.GetConnectionString("DefaultConnection");
                SqlConnection con = new SqlConnection(connString);
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "searchquery";
                    cmd.CommandText = "searchqueryFrontWebsite";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@searchkeyword", txtsearch);
                    cmd.Parameters.AddWithValue("@Latitude", 0);
                    cmd.Parameters.AddWithValue("@Longitude", 0);
                    cmd.Parameters.AddWithValue("@cityid",cityid);
                    
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    

                    


                    if (ds != null)
                    {
                        try
                        {


                            if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "sector".ToString().ToLower().Trim())
                            {
                                objmodel.SearchModelType = "sector".ToString().ToLower().Trim();
                                objmodel.objSectorRegistration = ds.Tables[0].AsEnumerable().Select(row => new SectorRegistrationIndexViewModel
                                {
                                    id = Convert.ToInt32(row["id"].ToString()),
                                    name = row["name"].ToString(),
                                    img = row["img"].ToString()
                                });

                                // public IEnumerable<SectorRegistrationIndexViewModel> objSectorRegistration { get; set; }
                            }
                            else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "business".ToString().ToLower().Trim())
                            {
                                objmodel.SearchModelType = "business".ToString().ToLower().Trim();
                                //   public IEnumerable<search_BusinessRegistrationIndexViewModel> objsearch_BusinessRegistrationIndexViewModel { get; set; }
                                objmodel.objsearch_BusinessRegistrationIndexViewModel = ds.Tables[0].AsEnumerable().Select(row => new search_BusinessRegistrationIndexViewModel
                                {
                                    id = Convert.ToInt32(row["id"].ToString()),
                                    name = row["name"].ToString(),
                                    img = row["img"].ToString(),
                                    sectorid = Convert.ToInt32(row["sectorid"].ToString()),
                                    type = row["type"].ToString()
                                });

                            }
                            else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "product".ToString().ToLower().Trim())
                            {
                                objmodel.SearchModelType = "product".ToString().ToLower().Trim();
                                // public IEnumerable<search_ProductIndexViewModel> objsearch_ProductIndexViewModel { get; set; }
                                objmodel.objsearch_ProductIndexViewModel = ds.Tables[0].AsEnumerable().Select(row => new search_ProductIndexViewModel
                                {
                                    id = Convert.ToInt32(row["id"].ToString()),
                                    businessid = Convert.ToInt32(row["businessid"].ToString()),
                                    productName = row["productName"].ToString(),
                                    img = row["img"].ToString(),

                                    type = row["type"].ToString()
                                });

                            }
                            else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "businessowner".ToString().ToLower().Trim())
                            {
                                // selectallBusinessDetailsDtos
                                //objmodel.objBusinessDetails = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);

                                objmodel.objBusinessDetails = ds.Tables[0].AsEnumerable().Select(row => new selectallBusinessDetailsDtos
                                {         //                        

                                    Id = Convert.ToString(row["Id"].ToString()),
                                    name = Convert.ToString(row["name"].ToString()),
                                    description = row["description"].ToString(),
                                    profilephoto = row["profilephoto"].ToString(),
                                    mobileno2 = Convert.ToString(row["mobileno2"].ToString()),
                                    PhoneNumber = Convert.ToString(row["PhoneNumber"].ToString()),
                                    rating = Convert.ToInt32(row["rating"].ToString()),
                                    cityname = row["cityname"].ToString(),
                                    businesstime = Convert.ToString(row["businesstime"].ToString()),
                                    Email = Convert.ToString(row["Email"].ToString()),


                                });


                                //objmodel.SearchModelType = "businessowner".ToString().ToLower().Trim();
                                ////public IEnumerable<search_BusinessOwnerRegistrationDtos> objsearch_BusinessOwnerRegistrationDtos { get; set; }
                                //objmodel.objsearch_BusinessOwnerRegistrationDtos = ds.Tables[0].AsEnumerable().Select(row => new search_BusinessOwnerRegistrationDtos
                                //{
                                //    id = Convert.ToString(row["id"].ToString()),
                                //    name = Convert.ToString(row["name"].ToString()),
                                //    profilephoto = row["profilephoto"].ToString(),
                                //    mobileno1 = row["mobileno1"].ToString(),
                                //    mobileno2 = Convert.ToString(row["mobileno2"].ToString()),
                                //    emailid1 = Convert.ToString(row["emailid1"].ToString()),
                                //    emailid2 = row["emailid2"].ToString(),
                                //    adharcardno = row["adharcardno"].ToString(),
                                //    adharcardphoto = Convert.ToString(row["adharcardphoto"].ToString()),
                                //    pancardno = Convert.ToString(row["pancardno"].ToString()),
                                //    pancardphoto = row["pancardphoto"].ToString(),
                                //    gender = row["gender"].ToString(),
                                //    DOB = Convert.ToDateTime(row["DOB"].ToString()),
                                //    house = Convert.ToString(row["house"].ToString()),
                                //    landmark = row["landmark"].ToString(),
                                //    street = row["street"].ToString(),

                                //    cityid = row["cityid"].ToString(),
                                //    zipcode = row["zipcode"].ToString(),
                                //    latitude = Convert.ToString(row["latitude"].ToString()),
                                //    longitude = Convert.ToString(row["longitude"].ToString()),
                                //    companyName = row["companyName"].ToString(),
                                //    designation = row["designation"].ToString(),
                                //    gstno = Convert.ToString(row["gstno"].ToString()),
                                //    Website = Convert.ToString(row["Website"].ToString()),
                                //    Regcertificate = row["Regcertificate"].ToString(),
                                //    businessid = row["businessid"].ToString(),
                                //    productid = Convert.ToString(row["productid"].ToString()),
                                //    lic = row["lic"].ToString(),
                                //    registerbyAffilateID = row["registerbyAffilateID"].ToString(),

                                //    deviceid = Convert.ToString(row["deviceid"].ToString()),
                                //    type = row["type"].ToString(),

                                //});



                            }
                            else
                            {

                            }
                        }
                        catch (Exception obj)
                        {
                            objmodel.SearchModelType = "NotFound";
                        }
                    }
                    else
                    {
                        objmodel.SearchModelType = "NotFound";
                    }

                }
                catch(Exception obj)
                {
                    objmodel.SearchModelType = "Record Not Found";
                    //string myJson2 = "{\"Message\": " + "\"Not Found\"" + "}";
                    //return NotFound(myJson2);
                }
                finally { con.Close(); }


                //--------------------------------------------------------------------------------------
                return View(objmodel);
            }
            catch (Exception obj)
            {

            }
            return View();
            //try
            //{
            //    ViewBag.search = txtsearch;

            //    var parameter = new DynamicParameters();
            //    //  parameter.Add("@businessid", businessid);
            //    // var obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null );
            //    IEnumerable<selectallBusinessDetailsDtos> obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", null);

            //    return View(obj);


            //}
            //catch (Exception obj)
            //{

            //}
            //return View();
        }
        //private Task<IdentityUser> GetCurrentUserAsync() =>  _usermanager.GetUserAsync(this.User);
        
        [HttpPost]
        public async Task<string> AddReview(string rating, int bussinessid, string review)
        {
            var customerId =User.FindFirstValue(ClaimTypes.NameIdentifier);


           // var businessId = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == bussinessid).FirstOrDefault();
            businessrating obj = new businessrating();
            obj.id = 0;
            obj.CustomerId = customerId;
            //obj.BusinessOwnerId =(int)businessId.id;
            obj.BusinessOwnerId =(int)bussinessid;
            obj.rating = rating;
            obj.comment = review;
            obj.isdeleted = false;
            await _businessratingsServices.CreateAsync(obj);

            return "complete";
        }

        [HttpGet]
        public IActionResult business(string id)
        {
          //  LoginUserDetails();
            businessDetailsViewModel obj = new businessDetailsViewModel();


            var parameter = new DynamicParameters();
            parameter.Add("@Id", id);

            obj.objgetBusinessAllInfo = _sP_Call.OneRecord<getBusinessAllInfo>("selectallBusinessDetailsAllInfo", parameter);

            //var parameter1 = new DynamicParameters();
            //parameter1.Add("@BusinessOwnerId", id);
            obj.objbusinessrating = _sP_Call.List<selectallBusinessRatingViewModel>("selectallBusinessRating", parameter);


            //------------
            string markers = "[";
            markers += "{";
            markers += string.Format("'title': '{0}',", obj.objgetBusinessAllInfo.companyName);
            markers += string.Format("'lat': '{0}',", obj.objgetBusinessAllInfo.latitude);
            markers += string.Format("'lng': '{0}',", obj.objgetBusinessAllInfo.longitude);
            markers += string.Format("'description': '{0}'", obj.objgetBusinessAllInfo.description);
            markers += "}";
            markers += "];";
            ViewBag.Markers = markers;
            if (obj == null)
            {
                return View();
            }
            else
            {
                return View(obj);

            }



        }

        [HttpGet]
        public IActionResult businessDetails(int sectorid)
        {
          //  LoginUserDetails();
            //var obj = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == sectorid && x.isdeleted == false).Select(x => new BusinessRegistrationIndexViewModel
            //{
            //    id = x.id,
            //    sectorid = x.sectorid,
            //    name = x.name,
            //    SectorRegistration = _SectorRegistrationServices.GetById(x.sectorid),
            //    img = x.img,
            //    photo = x.photo

            //}).ToList();
            //return View(obj);
            var obj = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == sectorid && x.isdeleted == false).ToList();
            return View(obj);
        }
        [HttpGet]
        public IActionResult productDetails(int businessid)
        {
           // LoginUserDetails();
            var obj = _productMasterServices.GetAll().Where(x => x.businessid == businessid && x.isdeleted == false).Select(x => new ProductIndexViewModel
            {


                id = x.id,
                //sectorid = x.se,
                businessid = x.businessid,
                productName = x.productName,
                BusinessRegistration = _BusinessRegistrationServieces.GetById(x.businessid),
                SectorRegistration = _SectorRegistrationServices.GetById(_BusinessRegistrationServieces.GetById(x.businessid).sectorid),
                img = x.img

            }).ToList();
            return View(obj);
        }


        public IActionResult Privacy()
        {
           // LoginUserDetails();
            return View();
        }
        public IActionResult about()
        {
          //  LoginUserDetails();
            AboutUs obj = _aboutUsServices.GetById(1);
            return View(obj);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult ContactUs()
        {
           // LoginUserDetails();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(ContactUsViewModel model)
        {

            if (ModelState.IsValid)
            {
                var obj = new ContactUs
                {
                    id = model.id
       ,
                    name = model.name
       ,
                    Email = model.Email
       ,
                    Mobileno = model.Mobileno
       ,
                    Address = model.Address

                };

                Int32 id = await _ContactUsServices.CreateAsync(obj);
                //var postId = await _CustomerRegistrationservices.CreateAsync(objcustomerRegistration);
                return RedirectToAction(nameof(Index));

            }
            else
            {
                return View();
            }

        }



        public IActionResult SubscribeDetails(Subscribe obj)
        {
            return View();
        }

        //private void AddDetails(EmpModel obj)
        //{
        //    connection();
        //    SqlCommand com = new SqlCommand("AddEmp", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@Name", obj.Name);
        //    com.Parameters.AddWithValue("@City", obj.City);
        //    com.Parameters.AddWithValue("@Address", obj.Address);
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();

        //}


        public IActionResult BusinessListing(int productid)
        {
           // LoginUserDetails();
            BusinessListingViewModel obj = new BusinessListingViewModel();

           
            try
            {
                int businessid = _productMasterServices.GetById(productid).businessid;
                obj.objProductIndexViewModel = _productMasterServices.GetAll().Where(x=>x.businessid==businessid).Select(x => new ProductIndexViewModel
                {


                    id = x.id,
                    //sectorid = x.se,
                    businessid = x.businessid,
                    productName = x.productName,
                    // BusinessRegistration = _BusinessRegistrationServiecess.GetById(x.businessid),
                    // SectorRegistration = _SectorRegistrationServices.GetById(_BusinessRegistrationServiecess.GetById(x.businessid).sectorid),
                    img = x.img

                }).ToList();
                var parameter = new DynamicParameters();
                parameter.Add("@productid", productid);
                // parameter.Add("@productid", 4);

                //   obj.objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductId", parameter);

                obj.objgetBusinessAllInfo = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo_byyProductIdTest", parameter);

            }
            catch(Exception objmsg)
            {
                string p = objmsg.Message;
            }
          
             

           
            return View(obj);
            //return View();
        }



        [HttpGet]
        public IActionResult Category()
        {
          //  LoginUserDetails();
            var parameter = new DynamicParameters();
            IEnumerable<selectallSectorWithBusinessCount> obj = _sP_Call.List<selectallSectorWithBusinessCount>("selectallSectorWithBusinessCount", null);

            return View(obj);
        }
        [HttpGet]
        public IActionResult Advertising()
        {
          //  LoginUserDetails();
            return View();
        }


        public IActionResult TermsandConditions()
        {
           // LoginUserDetails();
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
          //  LoginUserDetails();
            return View();
        }


    }
}
