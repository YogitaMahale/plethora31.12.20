
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Services;
//using BusinessOwnerRegiIndexViewModel = plathora.Models.BusinessOwnerRegiIndexViewModel;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace plathora.API
{
    [Route("BusinessOwner")]
    //[ApiController]
    public class BusinessOwnerController : ControllerBase
    {
        private readonly IBusinessOwnerRegiServices _BusinessOwnerRegiServices;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ISP_Call _sP_Call;
        private readonly IBusinessPackageServices _businessPackageServices;
        public BusinessOwnerController(IBusinessOwnerRegiServices BusinessOwnerRegiServices, IWebHostEnvironment hostingEnvironment, ISP_Call sP_Call, IBusinessPackageServices businessPackageServices)
        {
            _BusinessOwnerRegiServices = BusinessOwnerRegiServices;
            _hostingEnvironment = hostingEnvironment;
            _sP_Call = sP_Call;
            _businessPackageServices = businessPackageServices;
        }
        //[HttpGet]
        //[Route("businessOwnerLogin")]
        //public async Task<IActionResult> businessOwnerLogin(string mobileNo, string password)
        //{
        //    try
        //    {
        //        BusinessOwnerRegi obj = _BusinessOwnerRegiServices.GetAll().Where(x => x.mobileno1 == mobileNo && x.password == password).FirstOrDefault();
        //        if (obj == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(obj);
        //        }
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}

        [HttpPost]
        [Route("saveBusinessDetails")]
        public async Task<IActionResult> saveBusinessDetails(BusinessOwnerRegistrationDtos model)
        {
            //BusinessOwnerRegi obj1 = new BusinessOwnerRegi();
            //  obj1 = _BusinessOwnerRegiServices.GetAll().Where(x => x.customerid == model.customerid).FirstOrDefault();
            //if (obj1 == null)
            //{
               

                BusinessOwnerRegi obj = new BusinessOwnerRegi();
                obj.id = model.id;
                obj.customerid = model.customerid;
                obj.description = model.description;
                obj.Regcertificate = model.Regcertificate;
                obj.businessid = model.businessid;
                obj.productid = model.productid ;
                obj.lic = model.lic ;
                obj.MondayOpen = model.MondayOpen;
                obj.MondayClose = model.MondayClose;
                obj.TuesdayOpen = model.TuesdayOpen;
                obj.TuesdayClose = model.TuesdayClose;
                obj.WednesdayOpen = model.WednesdayOpen;
                obj.WednesdayClose = model.WednesdayClose;
                obj.ThursdayOpen = model.ThursdayOpen;
                obj.ThursdayClose = model.ThursdayClose;
                obj.FridayOpen = model.FridayOpen;
                obj.FridayClose = model.FridayClose;
                obj.SaturdayOpen = model.SaturdayOpen;
                obj.SaturdayClose = model.SaturdayClose;
                obj.SundayOpen = model.SundayOpen;
                obj.SundayClose = model.SundayClose;
                obj.CallCount = model.CallCount;
                obj.SMSCount = model.SMSCount;
                obj.WhatssappCount = model.WhatssappCount;
                obj.ShareCount = model.ShareCount;

                obj.facebookLink = model.facebookLink;
                obj.googleplusLink = model.googleplusLink;
                obj.instagramLink = model.instagramLink;
                obj.linkedinLink = model.linkedinLink;
                obj.twitterLink = model.twitterLink;
                obj.youtubeLink = model.youtubeLink;



                //------payment ----------------------
                int BusinessPackageId =(int) model.BusinessPackageId;
                string  month = _businessPackageServices.GetById(BusinessPackageId).period;

                obj.Registrationdate = DateTime.Now;
                obj.Expirydate = DateTime.Now.AddMonths(Convert.ToInt32(month));
                obj.PaymentStatus = model.PaymentStatus;
                obj.PaymentAmount = model.PaymentAmount;
                obj.TransactionId = model.TransactionId;


                // obj.MembershipId = model.MembershipId;
                obj.house = model.house;
                obj.landmark = model.landmark;
                obj.street = model.street;
                obj.cityid = model.cityid;
                obj.zipcode = model.zipcode;
                obj.latitude = model.latitude;
                obj.longitude = model.longitude;
                obj.companyName = model.companyName;
                obj.gstno = model.gstno;
                obj.Website = model.Website;
                obj.businessOperation = model.businessOperation;
                obj.businessType = model.businessType;
                obj.registerbyAffilateUniqueId = model.UniqueId;
            obj.organization = model.organization;

            if (model.sliderimg1 == null || model.sliderimg1 == string.Empty)
                {
                    obj.sliderimg1 = "";

                }
                else
                {
                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg1));
                    obj.sliderimg1 = "/uploads/businessowner/slider/" + filename;
                }

                if (model.sliderimg2 == null || model.sliderimg2 == string.Empty)
                {
                    obj.sliderimg2 = "";

                }
                else
                {
                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg2));
                    obj.sliderimg2 = "/uploads/businessowner/slider/" + filename;
                }
                if (model.sliderimg3 == null || model.sliderimg3 == string.Empty)
                {
                    obj.sliderimg3 = "";

                }
                else
                {
                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg3));
                    obj.sliderimg3 = "/uploads/businessowner/slider/" + filename;
                }

                if (model.sliderimg4 == null || model.sliderimg4 == string.Empty)
                {
                    obj.sliderimg4 = "";

                }
                else
                {
                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg4));
                    obj.sliderimg4 = "/uploads/businessowner/slider/" + filename;
                }
                if (model.sliderimg5 == null || model.sliderimg5 == string.Empty)
                {
                    obj.sliderimg5 = "";

                }
                else
                {
                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg5));
                    obj.sliderimg5 = "/uploads/businessowner/slider/" + filename;
                }
                 
                
                    if (obj == null)
                    {
                        return NotFound();
                    }
                    else
                    {

                        var postid = await _BusinessOwnerRegiServices.CreateAsync(obj);
                        int id = Convert.ToInt32(postid);
                        if (id ==0)
                        {
                            return BadRequest();
                        }
                        else
                        {
                            var customer1 = _BusinessOwnerRegiServices.GetById(id);                           
                            string obj11 = "{\"success\" : 1, \"message\" : \" Data\", \"data\" :" + customer1.id + "}";
                            return Ok(obj11);
                        }

                    }


               

            //}
            //else
            //{
            //    return BadRequest("Duplicate Record");
            //}

             
        }
     
        [HttpPut]
        [Route("updateBusinessDetails")]
        public async Task<IActionResult> updateBusinessDetails(BusinessOwnerRegistrationDtos model)
        {

            BusinessOwnerRegi obj1 = new BusinessOwnerRegi();
            obj1 = _BusinessOwnerRegiServices.GetAll().Where(x => x.customerid == model.customerid).FirstOrDefault();
            if (obj1 == null)
            {
                return NotFound();
            }
            else
            {
                obj1.id = model.id;
                obj1.customerid = model.customerid;
                obj1.description = model.description;
                obj1.Regcertificate = model.Regcertificate;
                obj1.businessid = model.businessid;
                obj1.productid = model.productid;
                obj1.lic = model.lic;
                obj1.MondayOpen = model.MondayOpen;
                obj1.MondayClose = model.MondayClose;
                obj1.TuesdayOpen = model.TuesdayOpen;
                obj1.TuesdayClose = model.TuesdayClose;
                obj1.WednesdayOpen = model.WednesdayOpen;
                obj1.WednesdayClose = model.WednesdayClose;
                obj1.ThursdayOpen = model.ThursdayOpen;
                obj1.ThursdayClose = model.ThursdayClose;
                obj1.FridayOpen = model.FridayOpen;
                obj1.FridayClose = model.FridayClose;
                obj1.SaturdayOpen = model.SaturdayOpen;
                obj1.SaturdayClose = model.SaturdayClose;
                obj1.SundayOpen = model.SundayOpen;
                obj1.SundayClose = model.SundayClose;
                obj1.CallCount = model.CallCount;
                obj1.SMSCount = model.SMSCount;
                obj1.WhatssappCount = model.WhatssappCount;
                obj1.ShareCount = model.ShareCount;

                obj1.facebookLink = model.facebookLink;
                obj1.googleplusLink = model.googleplusLink;
                obj1.instagramLink = model.instagramLink;
                obj1.linkedinLink = model.linkedinLink;
                obj1.twitterLink = model.twitterLink;
                obj1.youtubeLink = model.youtubeLink;

                // obj.MembershipId = model.MembershipId;
                obj1.house = model.house;
                obj1.landmark = model.landmark;
                obj1.street = model.street;
                obj1.cityid = model.cityid;
                obj1.zipcode = model.zipcode;
                obj1.latitude = model.latitude;
                obj1.longitude = model.longitude;
                obj1.companyName = model.companyName;
                obj1.gstno = model.gstno;
                obj1.Website = model.Website;
                obj1.businessOperation = model.businessOperation;
                obj1.businessType = model.businessType;


                if (model.sliderimg1 != null || model.sliderimg1 != string.Empty)
                {

                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg1));
                    obj1.sliderimg1 = "/uploads/businessowner/slider/" + filename;
                }

                if (model.sliderimg2 != null || model.sliderimg2 != string.Empty)
                {
                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg2));
                    obj1.sliderimg2 = "/uploads/businessowner/slider/" + filename;
                }
                if (model.sliderimg3 != null || model.sliderimg3 != string.Empty)
                {

                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg3));
                    obj1.sliderimg3 = "/uploads/businessowner/slider/" + filename;
                }

                if (model.sliderimg4 != null || model.sliderimg4 != string.Empty)
                {

                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg4));
                    obj1.sliderimg4 = "/uploads/businessowner/slider/" + filename;
                }
                if (model.sliderimg5 != null || model.sliderimg5 != string.Empty)
                {

                    string filename = Guid.NewGuid().ToString();
                    filename = DateTime.UtcNow.ToString("yymmssfff") + filename + ".jpg";
                    var folderpath = _hostingEnvironment.WebRootPath + @"\uploads\businessowner\slider";
                    if (!System.IO.Directory.Exists(folderpath))
                    {
                        System.IO.Directory.CreateDirectory(folderpath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderpath, filename), Convert.FromBase64String(model.sliderimg5));
                    obj1.sliderimg5 = "/uploads/businessowner/slider/" + filename;
                }
                await _BusinessOwnerRegiServices.UpdateAsync(obj1);
                return Ok(obj1);
            }

        }
       
     //[HttpPut]
     //[Route("updateBusinessDeviceId")]
     //public async Task<IActionResult> updateBusinessDeviceId([FromUri] string deviceId, [FromUri] int id)
     //{
     //    var customer = _BusinessOwnerRegiServices.GetById(id);
     //    if (customer == null)
     //    {
     //        return NotFound();
     //    }
     //    else
     //    {
     //        customer.deviceid = deviceId;
     //        await _BusinessOwnerRegiServices.UpdateAsync(customer);

     //        if (id < 0)
     //        {
     //            return BadRequest();
     //        }
     //        else
     //        {

     //            return Ok(customer);
     //        }
     //    }



     //    return BadRequest();
     //}
        

    [HttpPut]
    [Route("updateBusinessOpeningHours")]
    public async Task<IActionResult> updateBusinessOpeningHours(BusinessOpeningHoursViewModel model)
    {

        var obj = _BusinessOwnerRegiServices.GetAll().Where(x => x.customerid == model.customerid).FirstOrDefault();
        if (obj == null)
        {
            return BadRequest("Record Not Found");

        }
        else
        {

            obj.MondayOpen = model.MondayOpen;
            obj.MondayClose = model.MondayClose;
            obj.TuesdayOpen = model.TuesdayOpen;
            obj.TuesdayClose = model.TuesdayClose;
            obj.WednesdayOpen = model.WednesdayOpen;
            obj.WednesdayClose = model.WednesdayClose;
            obj.ThursdayOpen = model.ThursdayOpen;
            obj.ThursdayClose = model.ThursdayClose;
            obj.FridayOpen = model.FridayOpen;
            obj.FridayClose = model.FridayClose;
            obj.SaturdayOpen = model.SaturdayOpen;
            obj.SaturdayClose = model.SaturdayClose;
            obj.SundayClose = model.SundayClose;
            obj.SundayOpen = model.SundayOpen;

            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {

                    await _BusinessOwnerRegiServices.UpdateAsync(obj);


                    return Ok(obj);


                }


            }
            catch (Exception)
            {

                return BadRequest();
            }

        }


    }
    [HttpGet]
    [Route("GetBusinessbybusinssid")]
    public async Task<IActionResult> GetBusinessbybusinssid(int id)
    {
        try
        {
            var obj = _BusinessOwnerRegiServices.GetById(id);
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
    [HttpPut]
    [Route("updateCallCount")]
    public async Task<IActionResult> updateCallCount(int BusinessId)
    {

        var obj = _BusinessOwnerRegiServices.GetById(BusinessId);
        if (obj == null)
        {
            return BadRequest("Record Not Found");
        }
        else
        {
            int callcountobj = (obj.CallCount + 1);
            obj.CallCount = callcountobj;
            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    await _BusinessOwnerRegiServices.UpdateAsync(obj);
                    return Ok(obj);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

    [HttpPut]
    [Route("updateSMSCount")]
    public async Task<IActionResult> updateSMSCount(int BusinessId)
    {

        var obj = _BusinessOwnerRegiServices.GetById(BusinessId);
        if (obj == null)
        {
            return BadRequest("Record Not Found");
        }
        else
        {
            int smsCountobj = (obj.SMSCount + 1);
            obj.SMSCount = smsCountobj;
            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    await _BusinessOwnerRegiServices.UpdateAsync(obj);
                    return Ok(obj);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
    [HttpPut]
    [Route("updateShareCount")]
    public async Task<IActionResult> updateShareCount(int BusinessId)
    {

        var obj = _BusinessOwnerRegiServices.GetById(BusinessId);
        if (obj == null)
        {
            return BadRequest("Record Not Found");
        }
        else
        {
            int ShareCountobj = (obj.ShareCount + 1);
            obj.ShareCount = ShareCountobj;
            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    await _BusinessOwnerRegiServices.UpdateAsync(obj);
                    return Ok(obj);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

    [HttpPut]
    [Route("updateWhatsappCount")]
    public async Task<IActionResult> updateWhatsappCount(int BusinessId)
    {

        var obj = _BusinessOwnerRegiServices.GetById(BusinessId);
        if (obj == null)
        {
            return BadRequest("Record Not Found");
        }
        else
        {
            int WhatssappCountobj = (obj.WhatssappCount + 1);
            obj.WhatssappCount = WhatssappCountobj;
            try
            {
                if (obj == null)
                {
                    return NotFound();
                }
                else
                {
                    await _BusinessOwnerRegiServices.UpdateAsync(obj);
                    return Ok(obj);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

    [HttpGet]
    [Route("getBusinessbDetailsbyLatitudeandLongitude")]
    public async Task<IActionResult> getBusinessbDetailsbyLatitudeandLongitude(decimal Latitude, decimal Longitude)
    {
        try
        {


            var parameter = new DynamicParameters();
            parameter.Add("@Latitude", Latitude);
            parameter.Add("@Longitude", Longitude);

            var obj = _sP_Call.List<BusinessOwnerRegiIndexViewModel>("getnearbybusiness", parameter);
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
    [Route("businesslistbyprouctid")]
    public async Task<IActionResult> businesslistbyprouctid(int productid)
    {
        try
        {


            var parameter = new DynamicParameters();
            parameter.Add("@productid", productid);


            var obj = _sP_Call.List<BusinessOwnerRegiIndexViewModel>("businesslistbyprouctid", parameter);
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
    [Route("getLeadListbyCustomerid")]
    public async Task<IActionResult> getLeadListbyCustomerid(string  customerid)
    {
        try
        {
            var obj = _BusinessOwnerRegiServices.GetAll().Where(x => x.customerid == customerid);
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
    [Route("GetBusinessbyCustomerId")]
    public async Task<IActionResult> GetBusinessbyCustomerId(string  customerid)
    {
        try
        {
                var parameter = new DynamicParameters();
                parameter.Add("@Id", customerid);

                var obj = _sP_Call.List<getBusinessAllInfo>("selectallBusinessDetailsAllInfo", parameter);

                // var obj = _BusinessOwnerRegiServices.GetAll().Where(x => x.customerid == customerid).ToList();
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
   
    }
}

/*
id:11
name:yogita
profilephoto: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
mobileno1:9146582495
password:123
mobileno2:91465824
emailid1:test @gmail.com
emailid2:test @gmail.com
adharcardno:adrno
adharcardphoto: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
pancardno:pamnno
pancardphoto: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
password:123
gender:male
pinno:pin
DOB:06/06/2020
createddate:06/09/2020
isdeleted:false
isactive:false
house:house
landmark:landmark
street:street
cityid:1
zipcode:42200
latitude:24
longitude:24234
companyName:company nmae
designation:desig
gstno:gst
Website:websirte
Discription:desc
Regcertificate:receri
productid,:1
lic:lic
deviceid:4234
registerbyAffilateID:5
*/

