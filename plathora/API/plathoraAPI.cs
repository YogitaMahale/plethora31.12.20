using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Controllers;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Services;
using plathora.Models.Dtos;
using plathora.Persistence;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using SectorRegistrationIndexViewModel = plathora.Models.SectorRegistrationIndexViewModel;
using System.Runtime.CompilerServices;
using System.Xml;
using plathora.Services.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.API
{
    [Route("plathoraapi")]
    public class plathoraAPI : Controller
    {
        private readonly IBusinessRegistrationServieces _BusinessRegistrationServieces;
        private readonly ISectorRegistrationServices _SectorRegistrationServices;
        private readonly IProductMasterServices _ProductMasterServices;
        private readonly ICountryRegistrationservices _CountryRegistrationservices;
        private readonly IStateRegistrationService _StateRegistrationService;
        private readonly ICityRegistrationservices _CityRegistrationservices;
        private readonly IProductMasterServices _productMasterServices;
        private readonly  ISP_Call _sP_Call;
        private readonly IVideoServices _videoServices;
        private readonly IModuleMasterServices _moduleMasterServices;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly IsliderServices _sliderServices;
        //private readonly IadvertisementDetailsServices _advertisementDetailsServices;
        //private readonly IadvertisementtestServices _advertisementtestServices;
        private readonly IadvertisementInfoServices _advertisementInfoServices;
        private readonly IsocialsServices _socialsServices;
        private readonly Iratingsservices _ratingsservices;
        private readonly IbusinessratingsServices _businessratingsServices;
        private IConfiguration Configuration;
        private readonly ICustomerRegistrationservices _customerRegistrationservices;
        private readonly ItblfeedbackServices _tblfeedbackServices;
        private readonly IAdvertiseServices _advertiseServices;
        private readonly IAffilatePackageServices _affilatePackageServices;
         
        private readonly IMembershipServices _membershipServices;
        private readonly IsocialdetailsServices _socialdetailsServices;

        private readonly IcommissionServices _commissionServices;
        private readonly IAffilatePackageServices _AffilatePackageServices;
        private readonly IBusinessPackageServices _businessPackageServices;
        private readonly INewsServices _newsServices;
        private readonly IreferfriendSliderServices _referfriendSliderServices;
        public plathoraAPI(ISectorRegistrationServices SectorRegitrationServices, IBusinessRegistrationServieces BusinessRegistrationServieces, IProductMasterServices ProductMasterServices, ICountryRegistrationservices CountryRegistrationservices, IStateRegistrationService StateRegistrationService, ICityRegistrationservices CityRegistrationservices, IProductMasterServices productMasterServices, ISP_Call sP_Call, IVideoServices videoServices, IModuleMasterServices moduleMasterServices, IWebHostEnvironment hostEnvironment, IadvertisementInfoServices advertisementInfoServices, IsocialsServices socialsServices, IsliderServices sliderServices, Iratingsservices ratingsservices, IbusinessratingsServices businessratingsServices, IConfiguration _configuration, ICustomerRegistrationservices customerRegistrationservices, ItblfeedbackServices tblfeedbackServices, IAdvertiseServices advertiseServices, IAffilatePackageServices affilatePackageServices, IMembershipServices membershipServices, IsocialdetailsServices socialdetailsServices, IcommissionServices commissionServices, IAffilatePackageServices AffilatePackageServices, IBusinessPackageServices businessPackageServices, INewsServices newsServices, IreferfriendSliderServices referfriendSliderServices)
        {
            _SectorRegistrationServices = SectorRegitrationServices;
            _BusinessRegistrationServieces = BusinessRegistrationServieces;
            _ProductMasterServices = ProductMasterServices;
            _CountryRegistrationservices = CountryRegistrationservices;
            _StateRegistrationService = StateRegistrationService;
            _CityRegistrationservices = CityRegistrationservices;
            _productMasterServices = productMasterServices;
            _sP_Call = sP_Call;
            _videoServices = videoServices;
            _moduleMasterServices = moduleMasterServices;
            _hostEnvironment = hostEnvironment;
            //_advertisementDetailsServices = advertisementDetailsServices;
            //_advertisementtestServices = advertisementtestServices;
            _advertisementInfoServices = advertisementInfoServices;
            _socialsServices = socialsServices;
            _sliderServices = sliderServices;
            _ratingsservices = ratingsservices;
            _businessratingsServices = businessratingsServices;
            Configuration = _configuration;
            _customerRegistrationservices = customerRegistrationservices;
            _tblfeedbackServices = tblfeedbackServices;
            _advertiseServices = advertiseServices;
            _affilatePackageServices = affilatePackageServices;
            _membershipServices = membershipServices;
            _socialdetailsServices = socialdetailsServices;
            _commissionServices = commissionServices;
            _AffilatePackageServices = affilatePackageServices;
            _businessPackageServices = businessPackageServices;
            _newsServices = newsServices;
            _referfriendSliderServices = referfriendSliderServices;
        }
          
        [HttpGet]
        [Route("SectorSelectAll")]
        public async Task<IActionResult> SectorSelectAll()
        {
            try
            {
                IEnumerable<SectorRegistration> obj = _SectorRegistrationServices.GetAll();
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }
        [HttpGet]
        [Route("SearchSectorbyName")]
        public async Task<IActionResult> SearchSectorbyName(string name)
        {
            try
            {

                 
                var parameter = new DynamicParameters();
                parameter.Add("@name", name);

                var obj = _sP_Call.List<SectorRegistrationSearchViewModel>("SearchSectorbyName", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }
        [HttpGet]
        [Route("GetBusinessbySectorId")]
        public async Task<IActionResult> GetBusinessbySectorId(int id)
        {
            try
            {
                IEnumerable<BusinessRegistration> obj = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == id && x.isdeleted == false);
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();

                }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("GetProductbyBusinessId")]
        public async Task<IActionResult> GetProductbyBusinessId(int id)
        {
            try
            {
                IEnumerable<ProductMaster> obj = _ProductMasterServices.GetAll().Where(x => x.businessid == id && x.isdeleted == false);
                if (obj != null)
                {
                    return Ok(obj);

                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("CountrySelectAll")]
        public async Task<IActionResult> CountrySelectAll()
        {
            try
            {
                IEnumerable<CountryRegistration> obj = _CountryRegistrationservices.GetAll();
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetStatebyCountryId")]
        public async Task<IActionResult> GetStatebyCountryId(int id)
        {
            try
            {
                IEnumerable<StateRegistration> obj = _StateRegistrationService.GetAll().Where(x => x.countryid == id).ToList();
                if(obj==null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetCitybyStateId")]
        public async Task<IActionResult> GetCitybyStateId(int id)
        {
            try
            {
                IEnumerable<CityRegistration> obj = _CityRegistrationservices.GetAll().Where(x => x.stateid  == id).ToList();
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetProductDetaildsbyProductid")]
        public async Task<IActionResult> GetProductDetaildsbyProductid(int id)
        { 
            try
            {
                IEnumerable<ProductMaster> obj = _productMasterServices.GetAll().Where(x => x.id == id).ToList();
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getVideos")]
        public async Task<IActionResult> getVideos()
        {
            try
            {
                // IEnumerable<Videos> obj = _videoServices.GetAll();
                var obj = _videoServices.GetAll().Select(x => new VideoIndexViewModel
                {



                    id = x.id,
                    fkmoduleid = x.fkmoduleid,
                    type = x.type,
                    videoName = x.videoName,
                    videoLink = x.videoLink,
                    description = x.description,
                    modulename = _moduleMasterServices.GetById(x.fkmoduleid).Name

                }).ToList();
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("selectAllModule")]
        public async Task<IActionResult> selectAllModule()
        {
            try
            {
                List<Moduledetails> nestedMenuList = new List<Moduledetails>();

               // List<NestedMenuDTO> nestedMenuList = new List<NestedMenuDTO>();
                var menuList = _moduleMasterServices.GetAll().ToList();
                foreach (var menu in menuList)
                {
                    var Moduledetailsobj = new Moduledetails
                    {
                        id = menu.id,
                        Name = menu.Name,
                        amount = menu.amount,
                        isactive = menu.isactive,
                        //videodetails = _videoServices.GetAll().Where(x => x.fkmoduleid == menu.id).ToList()
                        videodetails = _videoServices.GetAll().Where(x => x.fkmoduleid == menu.id).Select(x => new Videos
                        {
                            id=x.id
                            , fkmoduleid = x.fkmoduleid
                            , type = x.type
                            , videoName = x.videoName
                            , videoLink = x.videoLink
                            , description = x.description
                            , isdeleted = x.isdeleted
                            , isactive = x.isactive
                            ,
                            moduleMaster=null
                        }).ToList()

                    };
                    nestedMenuList.Add(Moduledetailsobj);
                }
                //var countrydetails = _MembershipServices.GetAll().Select(x => new MembershipIndexViewModel
                //{
                //    id = x.id,
                //    membershipName = x.membershipName,


                //}).ToList();


                //var obj = _moduleMasterServices.GetAll().Select(x => new Moduledetails
                //{



                //    id = x.id,
                //    Name = x.Name,
                //    amount = x.amount,
                //    isactive = x.isactive,
                //    videodetails = _videoServices.GetAll().Where(x => x.fkmoduleid == x.id).ToList()


                //}).ToList();
                if (nestedMenuList != null)
                {
                    return Ok(nestedMenuList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        [Route("SaveadvertisementInfos")]
        public async Task<IActionResult> SaveadvertisementInfos(advertisementInfoDtos model)
        {

            

        

            advertisementInfo obj = new advertisementInfo();
            obj.id = 0;
            obj.customerId = model.customerId;
          //  obj.cusotmerid = model.cusotmerid;
            obj.advertiseid = model.advertiseid;
            obj.startdate = model.startdate;
            obj.title = model.title;
            obj.videourl = model.videourl;
            obj.shortdesc = model.shortdesc;
            obj.longdesc = model.longdesc;            
            obj.isdeleted = false;

            obj.PaymentAmount = model.PaymentAmount;
            obj.PaymentStatus = model.PaymentStatus;
            obj.TransactionId = model.TransactionId;
            int pkgMonth = _advertiseServices.GetById(model.advertiseid).period;
            obj.Expirydate = model.startdate.AddMonths(pkgMonth);
            obj.AfilateuniqueId = model.uniqueId;
            if (model.image1 == null || model.image1 == string.Empty)
            {
                obj.image1 = "";

            }
            else
            {
                string filename = Guid.NewGuid().ToString();
                filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                var folderpath = _hostEnvironment.WebRootPath + @"\uploads\advertisementInfo";
                if (!System.IO.Directory.Exists(folderpath))
                {
                    System.IO.Directory.CreateDirectory(folderpath);
                }
                System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.image1));
                obj.image1 = "/uploads/advertisementInfo/" + filename;
            }
            if (model.image2 == null || model.image2 == string.Empty)
            {
                obj.image2 = "";

            }
            else
            {
                string filename = Guid.NewGuid().ToString();
                filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                var folderpath = _hostEnvironment.WebRootPath + @"\uploads\advertisementInfo";
                if (!System.IO.Directory.Exists(folderpath))
                {
                    System.IO.Directory.CreateDirectory(folderpath);
                }
                System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.image2));
                obj.image2 = "/uploads/advertisementInfo/" + filename;
            }

          

            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {

                    var postid = await _advertisementInfoServices.CreateAsync(obj);
                    int id = Convert.ToInt32(postid);
                    if (id < 0)
                    {
                        return BadRequest();
                    }
                    else
                    {


                        //commission calculateion
                        var parameter = new DynamicParameters();
                        parameter.Add("@id", postid);
                        _sP_Call.Execute("LevelWiseCommissionAdvertise", parameter);

                        var customer1 = _advertisementInfoServices.GetById(id);
                        return Ok(customer1);
                    }

                }


            }
            catch (Exception a)
            {

                return BadRequest();
            }



        }

        [HttpPost]
        [Route("insertSocialInfo")]
        public async Task<IActionResult> insertSocialInfo(socialDTos model)
        {


            social obj = new social();
            obj.id = 0;
            obj.customerid = model.customerid;
            obj.description = model.description;
            obj.isactive = false;
            obj.isdeleted = false;



            if (model.img == null || model.img == string.Empty)
            {
                obj.img = "";

            }
            else
            {
                string filename = Guid.NewGuid().ToString();
                filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                var folderpath = _hostEnvironment.WebRootPath + @"\uploads\social";
                if (!System.IO.Directory.Exists(folderpath))
                {
                    System.IO.Directory.CreateDirectory(folderpath);
                }
                System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.img));
                obj.img = "/uploads/social/" + filename;
            }
             
         

            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {

                    var postid = await _socialsServices.CreateAsync(obj);
                    int id = Convert.ToInt32(postid);
                    if (id < 0)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var customer1 = _socialsServices.GetById(id);
                        return Ok(customer1);
                    }

                }


            }
            catch (Exception a)
            {

                return BadRequest();
            }



        }
    
        [HttpGet]
        [Route("getAdvertisementInfo")]
        public async Task<IActionResult> getAdvertisementInfo()
        {
            try
            {


                //  var parameter = new DynamicParameters();
                // parameter.Add("@name", name);

                var obj = _sP_Call.List<SelectAllAdvertisementInfo>("selectAllAdvertisementInfo", null);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }

        [HttpGet]
        [Route("sliderselectall")]
        public async Task<IActionResult> sliderselectall()
        {
            try
            {
                var sliderlist = _sliderServices.GetAll().Where(x => x.isdeleted == false).ToList();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (sliderlist == null)
                {
                    return NotFound();
                }

                return Ok(sliderlist);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("insertRating")]
        public async Task<IActionResult> insertRating(int customerid,int affilateid,string rating)
        {

           
                rating obj = new rating();
                obj.customerid = customerid;                 
                obj.affilateid = affilateid;
                obj.ratingg = rating;
               
                
                try
                {
                    if (obj == null)
                    {
                        return NotFound();
                    }
                    else
                    {

                        var postId = await _ratingsservices.CreateAsync(obj);
                        int id = Convert.ToInt32(postId);
                        if (id < 0)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            var customer1 = _ratingsservices.GetById(id);
                            return Ok(customer1);
                        }

                    }


                }
                catch (Exception a)
                {

                    return BadRequest();
                }

                //}
             
            
             
        }

        //[HttpGet]
        //[Route("SectorSelectAlljson")]
        //public async Task<IActionResult> SectorSelectAlljson()
        //{
        //    try
        //    {
        //        IEnumerable<SectorRegistration> obj = _SectorRegistrationServices.GetAll();
        //        if (obj != null)
        //        {
        //            return Ok(obj);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch { return BadRequest(); }
        //}

        [HttpGet]
        [Route("SectorSelectAlljson")]
        public async Task<IActionResult> SectorSelectAlljson()
        {
            try
            {
                List<SectorRegistrationViewModeldtos> nestedMenuList = new List<SectorRegistrationViewModeldtos>();

                // List<NestedMenuDTO> nestedMenuList = new List<NestedMenuDTO>();
                var menuList = _SectorRegistrationServices.GetAll().ToList();
                foreach (var menu in menuList)
                {
                    var Moduledetailsobj = new SectorRegistrationViewModeldtos
                    {
                        id = menu.id
                        , name = menu.name
                        , isdeleted = menu.isdeleted
                        , isactive = menu.isactive
                        , img = menu.img

                       // , businessRegistration = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == menu.id && x.isdeleted == false).ToList()

                        // , businessRegistration = _BusinessRegistrationServieces.GetAll().Where(x => x.sectorid == menu.id && x.isdeleted == false).ToList()

                        , businessRegistrationdtos = _BusinessRegistrationServieces.GetAll().Where(x=>x.isdeleted==false&&x.sectorid==menu.id).Select(x => new BusinessRegistrationdtos
                        {
                            id=x.id,
                            sectorid=x.sectorid,
                            name=x.name,
                            img=x.img,
                            isdeleted=x.isdeleted,
                            isactive=x.isactive
 

                      }).ToList()






                };
                    nestedMenuList.Add(Moduledetailsobj);
                }
               
                if (nestedMenuList != null)
                {
                    return Ok(nestedMenuList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }
        [HttpGet]
        [Route("getproductbymultiplebusinessid")]
        public async Task<IActionResult> getproductbymultiplebusinessid(string businessid)
        {
            try
            {


                var parameter = new DynamicParameters();
                parameter.Add("@businessid", businessid);


                var obj = _sP_Call.List<ProductDtos>("getproductbymultiplebusinessid", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }

        [HttpPost]
        [Route("insertBusinessRating")]
        public async Task<IActionResult> insertBusinessRating(businessratingsDtos model)
        {


            businessrating obj = new businessrating();
            obj.id = 0;
            obj.CustomerId = model.CustomerId;
            obj.BusinessOwnerId = model.BusinessOwnerId;
            int rating1 = (int)Convert.ToDecimal(model.rating);
            obj.rating = rating1.ToString();
            obj.comment = model.comment;
             
            obj.isdeleted = false;




            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {

                    var postid = await _businessratingsServices.CreateAsync(obj);
                    int id = Convert.ToInt32(postid);
                    if (id < 0)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var customer1 = _businessratingsServices.GetById(id);
                        return Ok(customer1);
                    }

                }


            }
            catch (Exception a)
            {

                return BadRequest();
            }



        }

        [HttpGet]
        [Route("getBusinessRatingbyBusinessid")]
        public async Task<IActionResult> getBusinessRatingbyBusinessid(int businessid)
        {
            try
            {
                //   var rating = _businessratingsServices.GetAll().Where(x=>x.BusinessOwnerId==businessid).ToList();
                var parameter = new DynamicParameters();
                parameter.Add("@BusinessOwnerId", businessid);


                var rating = _sP_Call.List<BusinessRatingDtos>("getRatingbyBusinessId", parameter);


                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (rating == null)
                {
                    return NotFound();
                }

                return Ok(rating);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("searchquery")]
        public async Task<IActionResult> searchquery(string searchkeyword)
        {
            DataSet ds = new DataSet();
            
                string connString = this.Configuration.GetConnectionString("DefaultConnection");
                SqlConnection con = new SqlConnection(connString);
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "searchquery";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@searchkeyword", searchkeyword);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "sector".ToString().ToLower().Trim())
                        {


                            //List<SectorRegistrationIndexViewModel> objList = new List<SectorRegistrationIndexViewModel>();
                            List<search_SectorRegistrationIndexViewModel> objList = new List<search_SectorRegistrationIndexViewModel>();
                            foreach (DataRow _dataRow in ds.Tables[0].Rows)
                            {
                              search_SectorRegistrationIndexViewModel    obj = new search_SectorRegistrationIndexViewModel();
                                obj.id = Convert.ToInt32(_dataRow["id"]);
                                obj.name = Convert.ToString(_dataRow["name"]);
                                obj.img = Convert.ToString(_dataRow["img"]);
                                obj.type = Convert.ToString(_dataRow["type"]);
                                objList.Add(obj);

                                //string myJson = "{\"Message\": " + "\"Bad Request\"" + "\"data\"" + "}";
                                //return BadRequest(myJson);
                            }



                            return Ok(objList);
                        }
                        else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "business".ToString().ToLower().Trim())
                        {
                            //List<BusinessRegistrationIndexViewModel> objList = new List<BusinessRegistrationIndexViewModel>();
                            List<search_BusinessRegistrationIndexViewModel> objList = new List<search_BusinessRegistrationIndexViewModel>();
                            foreach (DataRow _dataRow in ds.Tables[0].Rows)
                            {
                                search_BusinessRegistrationIndexViewModel obj = new search_BusinessRegistrationIndexViewModel();
                                obj.id = Convert.ToInt32(_dataRow["id"]);
                                obj.sectorid = Convert.ToInt32(_dataRow["sectorid"]);
                                obj.name = Convert.ToString(_dataRow["name"]);
                                obj.img = Convert.ToString(_dataRow["img"]);
                                obj.type = Convert.ToString(_dataRow["type"]);
                                objList.Add(obj);
                            }
                            return Ok(objList);
                        }
                        else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "product".ToString().ToLower().Trim())
                        {

                            //List<ProductIndexViewModel> objList = new List<ProductIndexViewModel>();
                            List<search_ProductIndexViewModel> objList = new List<search_ProductIndexViewModel>();
                            foreach (DataRow _dataRow in ds.Tables[0].Rows)
                            {
                                search_ProductIndexViewModel obj = new search_ProductIndexViewModel();
                                obj.id = Convert.ToInt32(_dataRow["id"]);
                               // obj.sectorid = Convert.ToInt32(_dataRow["sectorid"]);
                                obj.businessid = Convert.ToInt32(_dataRow["businessid"]);
                                obj.productName = Convert.ToString(_dataRow["productName"]);
                                obj.img = Convert.ToString(_dataRow["img"]);
                                obj.type  = Convert.ToString(_dataRow["type"]);
                                // obj.BusinessRegistration = null;
                                // obj.SectorRegistration = null;
                                objList.Add(obj);
                            }
                            return Ok(objList);
                        }
                        else if (ds.Tables[0].Rows[0]["type"].ToString().ToLower().Trim() == "businessowner".ToString().ToLower().Trim())
                        {
                            //List<BusinessOwnerRegistrationDtos> objList = new List<BusinessOwnerRegistrationDtos>();
                            List<search_BusinessOwnerRegistrationDtos> objList = new List<search_BusinessOwnerRegistrationDtos>();
                            foreach (DataRow _dataRow in ds.Tables[0].Rows)
                            {
                                search_BusinessOwnerRegistrationDtos obj = new search_BusinessOwnerRegistrationDtos();
                                


                                obj.id = Convert.ToString (_dataRow["id"]);
                                obj.name = Convert.ToString(_dataRow["name"]);
                                obj.profilephoto = Convert.ToString(_dataRow["profilephoto"]);
                                obj.mobileno1 = Convert.ToString(_dataRow["mobileno1"]);


                                obj.mobileno2 = Convert.ToString(_dataRow["mobileno2"]);

                                obj.emailid1 = Convert.ToString(_dataRow["emailid1"]);


                                obj.emailid2 = Convert.ToString(_dataRow["emailid2"]);

                                obj.adharcardno = Convert.ToString(_dataRow["adharcardno"]);


                                obj.adharcardphoto = Convert.ToString(_dataRow["adharcardphoto"]);

                                obj.pancardno = Convert.ToString(_dataRow["pancardno"]);


                                obj.pancardphoto = Convert.ToString(_dataRow["pancardphoto"]);
                                //obj.password = Convert.ToString(_dataRow["password"]);
                                obj.gender = Convert.ToString(_dataRow["gender"]);
                              //  obj.pinno = Convert.ToString(_dataRow["pinno"]);
                                obj.DOB = Convert.ToDateTime(_dataRow["DOB"]);

                                obj.house = Convert.ToString(_dataRow["house"]);
                                obj.landmark = Convert.ToString(_dataRow["landmark"]);
                                obj.street = Convert.ToString(_dataRow["street"]);


                                obj.cityid = Convert.ToString (_dataRow["cityid"]);
                                obj.zipcode = Convert.ToString(_dataRow["zipcode"]);

                                obj.latitude = Convert.ToString(_dataRow["latitude"]);
                                obj.longitude = Convert.ToString(_dataRow["longitude"]);
                                obj.companyName = Convert.ToString(_dataRow["companyName"]);
                                obj.designation = Convert.ToString(_dataRow["designation"]);
                                obj.gstno = Convert.ToString(_dataRow["gstno"]);
                                obj.Website = Convert.ToString(_dataRow["Website"]);
                              //  obj.Discription = Convert.ToString(_dataRow["Discription"]);
                                obj.Regcertificate = Convert.ToString(_dataRow["Regcertificate"]);



                                obj.businessid = Convert.ToString(_dataRow["businessid"]);




                                obj.productid = Convert.ToString(_dataRow["productid"]);
                                obj.lic = Convert.ToString(_dataRow["lic"]);
                                obj.registerbyAffilateID = Convert.ToString(_dataRow["registerbyAffilateID"]);
                                obj.deviceid = Convert.ToString(_dataRow["deviceid"]);
                                obj.type = Convert.ToString(_dataRow["type"]);

                                objList.Add(obj);
                            }
                            return Ok(objList);
                        }
                        else
                        {
                            string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                            return NotFound(myJson);
                        }
                    }
                    else
                    {
                        string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                        return NotFound(myJson);
                    }

                }
                catch
              {
                string myJson2 = "{\"Message\": " + "\"Not Found\"" + "}";
                return NotFound(myJson2);
             }
                finally { con.Close(); }
            string myJson1 = "{\"Message\": " + "\"Not Found\"" + "}";
            return NotFound(myJson1);
            //var parameter = new DynamicParameters();
            //parameter.Add("@searchkeyword", searchkeyword);


            //var obj = _sP_Call.List<ProductDtos>("getproductbymultiplebusinessid", parameter);
            ////  var categories = await _context.CustomerRegistration.ToListAsync(); 
            //if (obj == null)
            //{

            //    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
            //    return NotFound(myJson);
            //}
            //else
            //{

            //    return Ok(obj);
            //}


            //}
            //catch (Exception obj)
            //{
            //    string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
            //    return BadRequest(myJson);

            //}

        }

        [HttpPost]
        [Route("insertFeedback")]
        public async Task<IActionResult> insertFeedback(FeedbackDtos model)
        {


            tblfeedback obj = new tblfeedback();
            obj.id = 0;
            obj.title = model.title;
            obj.desc = model.desc;
            obj.isdeleted = false;
            obj.customerid = model.customerid;
            if (model.img == null || model.img == string.Empty)
            {
                obj.img = "";


            }
            else
            {
                string filename = Guid.NewGuid().ToString();
                filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                var folderpath = _hostEnvironment.WebRootPath + @"\uploads\feedback";
                if (!System.IO.Directory.Exists(folderpath))
                {
                    System.IO.Directory.CreateDirectory(folderpath);
                }
                System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.img));
                obj.img = "/uploads/feedback/" + filename;
            }



            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {

                    var postid = await _tblfeedbackServices.CreateAsync(obj);
                    int id = Convert.ToInt32(postid);
                    if (id < 0)
                    {
                        return BadRequest();
                    }
                    else
                    {
                        var customer1 = _tblfeedbackServices.GetById(id);
                        return Ok(customer1);
                    }

                }


            }
            catch (Exception a)
            {

                return BadRequest();
            }



        }

        [HttpGet]
        [Route("AdvertiseSelectall")]
        public async Task<IActionResult> AdvertiseSelectall()
        {
            try
            {
                var sliderlist = _advertiseServices.GetAll().Where(x => x.isdeleted == false).ToList();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (sliderlist == null)
                {
                    return NotFound();
                }

                return Ok(sliderlist);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("affilatepackageSelectall")]
        public async Task<IActionResult> affilatepackageSelectall()
        {
            //try
            //{
            //    var sliderlist = _affilatePackageServices.GetAll().Where(x => x.isdeleted == false).ToList();
            //    //  var categories = await _context.CustomerRegistration.ToListAsync(); 
            //    if (sliderlist == null)
            //    {
            //        return NotFound();
            //    }

            //    return Ok(sliderlist);
            //}
            //catch (Exception obj)
            //{
            //    return BadRequest();
            //}
            try
            {


                var parameter = new DynamicParameters();
                //    parameter.Add("@name", name);

                var obj = _sP_Call.List<AffilatePackageSelectAllViewModel>("AffilatePackageSelectAll", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }


        [HttpPut]
        [Route("updateSocialLikeCnt")]
        public async Task<IActionResult> updateSocialLikeCnt(int socialId,string  customerid,int status)
        {

            var obj = _socialdetailsServices.GetAll().Where(x => x.socialid == socialId && x.customerid == customerid && x.isdeleted == false).FirstOrDefault();
            if (obj == null)
            {
                socialdetails obj1 = new socialdetails();
                obj1.id = 0;
                obj1.socialid = socialId;
                obj1.customerid = customerid;
                obj1.comment = "";
                obj1.LikeCnt = status;
                obj1.isdeleted = false;

                //ocialid, customerid, LikeCnt, comment, isdeleted
                int id = await _socialdetailsServices.CreateAsync(obj1);
                var details = _socialdetailsServices.GetById(id);
                return Ok(details);
            }
            else
            {
                obj.LikeCnt = status;  
                   await _socialdetailsServices.UpdateAsync(obj);                    
                        return Ok(obj);                   
                 
            }
        }

        [HttpPut]
        [Route("updateSocialComment")]
        public async Task<IActionResult> updateSocialComment(int socialId, string  customerid, string comment)
        {

            var obj = _socialdetailsServices.GetAll().Where(x => x.socialid == socialId && x.customerid == customerid && x.isdeleted == false).FirstOrDefault();
            if (obj == null)
            {
                socialdetails obj1 = new socialdetails();
                obj1.id = 0;
                obj1.socialid = socialId;
                obj1.customerid = customerid;
                obj1.comment = comment;
                obj1.LikeCnt = 0;
                obj1.isdeleted = false;

                //ocialid, customerid, LikeCnt, comment, isdeleted
                int id = await _socialdetailsServices.CreateAsync(obj1);
                var details = _socialdetailsServices.GetById(id);
                return Ok(details);
            }
            else
            {
                obj.comment = comment;
                await _socialdetailsServices.UpdateAsync(obj);
                return Ok(obj);

            }
        }

        [HttpGet]
        [Route("getSocialDetailsbySocialId")]
        public async Task<IActionResult> getSocialDetailsbySocialId(int socialId)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@id", socialId);

                var obj = _sP_Call.List<SocialDetailsbySocialIdDtos>("getSocialDetailsbySocialId", parameter);

                //var list = _socialsServices.GetById(socialId);
                ////  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {
                    return NotFound();
                }

                return Ok(obj);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("getSocialInfo")]
        public async Task<IActionResult> getSocialInfo(string  customerid)
        {
            try
            {


                var parameter = new DynamicParameters();
                parameter.Add("@customerid", customerid);

                var obj = _sP_Call.List<getSocialInfoDtos>("selectAllSocialsInfo", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }

        [HttpGet]
        [Route("getallCommentbysocialid")]
        public async Task<IActionResult> getallCommentbysocialid(int socialid)
        {
            try
            {


                var parameter = new DynamicParameters();
                parameter.Add("@socialId", socialid);

                var obj = _sP_Call.List<SocialDetailsbySocialIdnewDtos>("getallCommentbysocialid", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }

        [HttpGet]
        [Route("getAffilatePackagedetailsbyMembershipId")]
        public async Task<IActionResult> getAffilatePackagedetailsbyMembershipId(int id)
        {
            try
            {
                var obj = _affilatePackageServices.GetAll().Where(x=>x.membershipid==id).Select(x => new AffilatePackageIndexModel
                {


                    id = x.id,
                    membershipid = x.membershipid,
                    commissionid = x.commissionid,
                    amount = x.amount,
                    Description = x.Description
                   // Membership = null,
                    //commission = null

                }).ToList();
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(obj);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("test")]
        public async Task<IActionResult> test()
        {
            try
            {


                var parameter = new DynamicParameters();
            //    parameter.Add("@name", name);

                var obj = _sP_Call.List<selectallBusinessDetailsDtos>("selectallBusinessDetails", parameter);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }
                else
                {

                    return Ok(obj);
                }


            }
            catch (Exception obj)
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);

            }

        }

        [HttpGet]
        [Route("BusinessPackageSelectAll")]
        public async Task<IActionResult> BusinessPackageSelectAll()
        {
            try
            {
                IEnumerable<BusinessPackage> obj = _businessPackageServices.GetAll().Where(x=>x.isdeleted==false);
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }


        [HttpGet]
        [Route("NewsSelectAll")]
        public async Task<IActionResult> NewsSelectAll()
        {
            try
            {
                IEnumerable<News> obj = _newsServices.GetAll();
                if (obj != null)
                {
                    return Ok(obj);
                }
                else
                {
                    return NotFound();
                }
            }
            catch { return BadRequest(); }
        }

        [HttpGet]
        [Route("referfriendSlider")]
        public async Task<IActionResult> referfriendSlider()
        {
            try
            {
                var sliderlist = _referfriendSliderServices.GetAll().Where(x => x.isdeleted == false).ToList();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (sliderlist == null)
                {
                    return NotFound();
                }

                return Ok(sliderlist);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
    }
}
