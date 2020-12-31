using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Services;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.API
{
    [Route("customers")]
    public class CustomerAPIController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICustomerRegistrationservices CustomerRegistrationservices;
        public CustomerAPIController(ICustomerRegistrationservices _CustomerRegistrationservices, IWebHostEnvironment hostingEnvironment)
        {
            CustomerRegistrationservices = _CustomerRegistrationservices;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            try
            {
                IEnumerable<CustomerRegistration> c = CustomerRegistrationservices.GetAll();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        [Route("GetCustomerbyId")]
        public async Task<IActionResult> GetCustomerbyId(int id)
        {
            try
            {
                CustomerRegistration c = CustomerRegistrationservices.GetById(id); 
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("CustomerLogin")]
        public async Task<IActionResult> CustomerLogin(string mobileno,string password)
        {
            try
            {
                IEnumerable<CustomerRegistration> c = CustomerRegistrationservices.GetAll().Where(x=>x.mobileno1==mobileno&&x.password==password&&x.isdeleted==false);
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (c == null)
                {
                    return NotFound();
                }

                return Ok(c);
            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }

        //[HttpPost]
        //[Route("SaveCustomer")]
        //public async Task<IActionResult> SaveCustomer([FromUri] string name , [FromUri] string address,[FromUri] string mobileno,[FromUri] string password,[FromUri] string gender, [FromUri] string ProfileImg, [FromUri] string ImgExtension)
        //{
        //    var checkduplicate = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
        //    if (checkduplicate == null)
        //    {
        //        CustomerRegistration obj = new CustomerRegistration();
        //        obj.name = name;

        //        obj.address = address;
        //        obj.mobileno1 = mobileno;
        //        obj.mobileno2 = "";
        //        obj.emailid1 = "";
        //        obj.latitude = "";
        //        obj.longitude = "";
        //        obj.password = password;
        //        obj.gender = gender;
        //        obj.DOB = DateTime.UtcNow;
        //        obj.createddate = DateTime.UtcNow;
        //        obj.isactive = false;
        //        obj.isdeleted = false;
        //        if (ProfileImg != null || ProfileImg != string.Empty)
        //        {
        //            string fileName = Guid.NewGuid().ToString();
        //            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + "." + ImgExtension;
        //            var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\customer";
        //            if (!System.IO.Directory.Exists(folderPath))
        //            {
        //                System.IO.Directory.CreateDirectory(folderPath);
        //            }
        //            System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(ProfileImg));
        //            obj.profilephoto = "/uploads/customer/" + fileName;

        //        }
        //        else
        //        {
        //            obj.profilephoto = "";
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                if (obj == null)
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {

        //                    var postId = await CustomerRegistrationservices.CreateAsync(obj);
        //                    int id = Convert.ToInt32(postId);
        //                    if (id < 0)
        //                    {
        //                        return BadRequest();
        //                    }
        //                    else
        //                    {
        //                        var customer = CustomerRegistrationservices.GetById(id);
        //                        return Ok(customer);
        //                    }

        //                }


        //            }
        //            catch (Exception)
        //            {

        //                return BadRequest();
        //            }

        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Duplicate Mobile No");
        //    }

        //    return BadRequest();
        //}
        //// GET: api/<controller>

        [HttpPut]
        [Route("updateCustomerDeviceId")]
        public async Task<IActionResult> updateCustomerDeviceId([FromUri] string deviceId, [FromUri] int id)
        {
            var customer = CustomerRegistrationservices.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                customer.deviceid = deviceId;
                await CustomerRegistrationservices.UpdateAsync(customer);
                
                if (id < 0)
                {
                    return BadRequest();
                }
                else
                {
                     
                    return Ok(customer);
                }
            }
                       

              
            return BadRequest();
        }


        //[HttpPut]
        //[Route("updateCustomerProfile")]
        //public async Task<IActionResult> updateCustomerProfile([FromUri] int id, [FromUri] string name, [FromUri] string address,  [FromUri] string password, [FromUri] string gender, [FromUri] string ProfileImg, [FromUri] string ImgExtension)
        //{
        //    var obj = CustomerRegistrationservices.GetById(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        obj.name = name;

        //        obj.address = address;
                
                 
        //        obj.password = password;
        //        obj.gender = gender;
                
                 
                
        //        if (ProfileImg != null || ProfileImg != string.Empty)
        //        {
        //            string fileName = Guid.NewGuid().ToString();
        //            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + "." + ImgExtension;
        //            var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\customer";
        //            if (!System.IO.Directory.Exists(folderPath))
        //            {
        //                System.IO.Directory.CreateDirectory(folderPath);
        //            }
        //            System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(ProfileImg));
        //            obj.profilephoto = "/uploads/customer/" + fileName;

        //        }
                 

                 
        //        await CustomerRegistrationservices.UpdateAsync(obj);

        //        if (id < 0)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {

        //            return Ok(obj);
        //        }
        //    }



        //    return BadRequest();
        //}



        //[HttpPut]
        //[Route("UpdateCustomer")]
        //public async Task<IActionResult> UpdateCustomer([FromUri] int id,[FromUri] string name, [FromUri] string address,  [FromUri] string password, [FromUri] string gender, [FromUri] string ProfileImg, [FromUri] string ImgExtension)
        //{

        //    CustomerRegistration obj = CustomerRegistrationservices.GetById(id);
        //    obj.name = name;
        //    obj.profilephoto = "";
        //    obj.address = address;
        //   // obj.mobileno1 = mobileno;
        //    obj.mobileno2 = "";
        //    obj.emailid1 = "";
        //    obj.latitude = "";
        //    obj.longitude = "";
        //    obj.password = password;
        //    obj.gender = gender;
        //    obj.DOB = DateTime.UtcNow;
        //    obj.createddate = DateTime.UtcNow;
        //    obj.isactive = false;
        //    obj.isdeleted = false;
        //    if (ProfileImg != null || ProfileImg != string.Empty)
        //    {
        //        string fileName = Guid.NewGuid().ToString();
        //        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + "." + ImgExtension;
        //        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\customer";
        //        if (!System.IO.Directory.Exists(folderPath))
        //        {
        //            System.IO.Directory.CreateDirectory(folderPath);
        //        }
        //        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(ProfileImg));
        //        obj.profilephoto = "/uploads/customer/" + fileName;

        //    }          

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            if (obj == null)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                await CustomerRegistrationservices.UpdateAsync(obj);
        //                //var postId= CustomerRegistrationservices.CreateAsync(obj);
        //                return Ok("Record Updated");

        //            }


        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }

        //    }

        //    return BadRequest();
        //}



        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Route("customerDelete")]
        public async Task<IActionResult> customerDelete(int id)
        {
            if (id <= 0)
                return  BadRequest("Not a valid Customer id");

            CustomerRegistration obj = CustomerRegistrationservices.GetById(id);
            if(obj==null)
            {
                return BadRequest("Customer id Not  Found");
            }
            else
            {
              await   CustomerRegistrationservices.Delete(id);
                return Ok("Record Deleted");
            }

           
        }

        [HttpPost]
        [Route("SaveCustomer")]
        public async Task<IActionResult> SaveCustomer(CustomerRegistrationDto customer)
        {

            var checkduplicate = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == customer.mobileno1 && x.isdeleted == false).FirstOrDefault();
            if (checkduplicate == null)
            {
                CustomerRegistration obj = new CustomerRegistration();
                obj.name = customer.name;

                obj.address = customer.address;
                obj.mobileno1 = customer.mobileno1;
                obj.mobileno2 = customer.mobileno2;
                obj.emailid1 = customer.emailid1;
                obj.latitude = customer.latitude;
                obj.longitude = customer.longitude;
                obj.password = customer.password;
                obj.gender = customer.gender;
                obj.DOB = DateTime.UtcNow;
                obj.createddate = DateTime.UtcNow;
                obj.isactive = false;
                obj.isdeleted = false;
                if (customer.profilephoto == null || customer.profilephoto.Trim() == "")
                {
                    obj.profilephoto = "";
                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\customer";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(customer.profilephoto));
                    obj.profilephoto = "/uploads/customer/" + fileName;

                }

               

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (customer == null)
                        {
                            return NotFound();
                        }
                        else
                        {

                            var postId = await CustomerRegistrationservices.CreateAsync(obj);
                            int id = Convert.ToInt32(postId);
                            if (id < 0)
                            {
                                return BadRequest();
                            }
                            else
                            {
                                var customer1 = CustomerRegistrationservices.GetById(id);
                                return Ok(customer1);
                            }

                        }


                    }
                    catch (Exception)
                    {

                        return BadRequest();
                    }

                }
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("updateCustomer")]
        public async Task<IActionResult> updateCustomer(CustomerRegistrationDto customer)
        {

            var checkduplicate = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == customer.mobileno1 && x.isdeleted == false&&x.id!=customer.id).FirstOrDefault();
            if (checkduplicate == null)
            {
                CustomerRegistration obj = CustomerRegistrationservices.GetById(customer.id);
                obj.name = customer.name;

                obj.address = customer.address;
                obj.mobileno1 = customer.mobileno1;
                obj.mobileno2 = customer.mobileno2;
                obj.emailid1 = customer.emailid1;
                obj.latitude = customer.latitude;
                obj.longitude = customer.longitude;
                obj.password = customer.password;
                obj.gender = customer.gender;
                obj.DOB = DateTime.UtcNow;
                obj.createddate = DateTime.UtcNow;
                obj.isactive = false;
                obj.isdeleted = false;
                if(customer.profilephoto == null || customer.profilephoto.Trim()=="")
                {

                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\customer";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(customer.profilephoto));
                    obj.profilephoto = "/uploads/customer/" + fileName;

                }

              
               

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (customer == null)
                        {
                            return NotFound();
                        }
                        else
                        {

                             await CustomerRegistrationservices.UpdateAsync(obj);
                           
                                
                                return Ok(obj);
                            

                        }


                    }
                    catch (Exception)
                    {

                        return BadRequest();
                    }

                }
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }


        [System.Web.Http.HttpPatch]
        [Route("updateCustomerusingpatch")]
        public async Task<IActionResult> updateCustomerusingpatch(CustomerRegistrationDto customer)
        {

            var checkduplicate = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == customer.mobileno1 && x.isdeleted == false && x.id != customer.id).FirstOrDefault();
            if (checkduplicate == null)
            {
                CustomerRegistration obj = CustomerRegistrationservices.GetById(customer.id);
                obj.name = customer.name;

                obj.address = customer.address;
                obj.mobileno1 = customer.mobileno1;
                obj.mobileno2 = customer.mobileno2;
                obj.emailid1 = customer.emailid1;
                obj.latitude = customer.latitude;
                obj.longitude = customer.longitude;
                obj.password = customer.password;
                obj.gender = customer.gender;
                obj.DOB = DateTime.UtcNow;
                obj.createddate = DateTime.UtcNow;
                obj.isactive = false;
                obj.isdeleted = false;
                if (customer.profilephoto == null || customer.profilephoto.Trim() == "")
                {

                }
                else
                {
                    string fileName = Guid.NewGuid().ToString();
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                    var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\customer";
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }
                    System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(customer.profilephoto));
                    obj.profilephoto = "/uploads/customer/" + fileName;

                }




                if (ModelState.IsValid)
                {
                    try
                    {
                        if (customer == null)
                        {
                            return NotFound();
                        }
                        else
                        {

                            await CustomerRegistrationservices.UpdateAsync(obj);


                            return Ok(obj);


                        }


                    }
                    catch (Exception)
                    {

                        return BadRequest();
                    }

                }
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }



        [HttpPost]
        [Route("SaveCustomer1")]
        public async Task<IActionResult> SaveCustomer1(CustomerRegistrationOTPViewModel customer)
        {

            var checkduplicate = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == customer.mobileno1 && x.isdeleted == false).FirstOrDefault();
            if (checkduplicate == null)
            {
                CustomerRegistration obj = new CustomerRegistration();
                obj.name = customer.name;

                obj.address = customer.address;
                obj.mobileno1 = customer.mobileno1;
                obj.mobileno2 = "";
                obj.emailid1 = "";
                obj.latitude = "";
                obj.longitude = "";
                obj.password = customer.password;
                obj.gender = customer.gender;
                obj.DOB = DateTime.UtcNow;
                obj.createddate = DateTime.UtcNow;
                obj.isactive = false;
                obj.isdeleted = false;
                

                if (ModelState.IsValid)
                {
                    try
                    {
                        if (customer == null)
                        {
                            return NotFound();
                        }
                        else
                        {

                            var postId = await CustomerRegistrationservices.CreateAsync(obj);
                            int id = Convert.ToInt32(postId);
                            if (id < 0)
                            {
                                return BadRequest();
                            }
                            else
                            {
                                var customer1 = CustomerRegistrationservices.GetById(id);
                                return Ok(customer1);
                            }

                        }


                    }
                    catch (Exception)
                    {

                        return BadRequest();
                    }

                }
            }
            else
            {
                return BadRequest("Duplicate Mobile No");
            }

            return BadRequest();
        }


        [HttpGet]
        [Route("getOTPNo")]
        public async Task<IActionResult> getOTPNo(string mobileno)
        {
            try
            {

                String no = null;
                Random random = new Random();
                for (int i = 0; i < 1; i++)
                {
                    int n = random.Next(0, 999);
                    no += n.ToString("D4") + "";
                }
                #region "sms"
                try
                {

                    string Msg = "OTP :" + no + ".  Please Use this OTP.This is usable once and expire in 10 minutes";

                    string OPTINS = "STRLIT";

                    string type = "3";
                    string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "Bingo@5151" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileno + "&type=" + 3;

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();
                    //    Response.Write("Sent");
                }

                catch
                { }
                #endregion

                CustomerRegistrationOTPViewModel objCustomerRegistrationOTPViewModel = new CustomerRegistrationOTPViewModel();
                CustomerRegistration obj = CustomerRegistrationservices.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                //  var categories = await _context.CustomerRegistration.ToListAsync(); 
                if (obj == null)
                {



                    objCustomerRegistrationOTPViewModel.otpno = no;
                    return Ok(objCustomerRegistrationOTPViewModel);
                }
                else
                {
                    objCustomerRegistrationOTPViewModel.id = obj.id;

                    objCustomerRegistrationOTPViewModel.name = obj.name;
                    objCustomerRegistrationOTPViewModel.profilephoto = obj.profilephoto;
                    objCustomerRegistrationOTPViewModel.address = obj.address;
                    objCustomerRegistrationOTPViewModel.mobileno1 = obj.mobileno1;
                    objCustomerRegistrationOTPViewModel.mobileno2 = obj.mobileno2;
                    objCustomerRegistrationOTPViewModel.emailid1 = obj.emailid1;
                    objCustomerRegistrationOTPViewModel.latitude = obj.latitude;
                    objCustomerRegistrationOTPViewModel.longitude = obj.longitude;
                    objCustomerRegistrationOTPViewModel.password = obj.password;
                    objCustomerRegistrationOTPViewModel.gender = obj.gender;
                    objCustomerRegistrationOTPViewModel.DOB = obj.DOB;
                    objCustomerRegistrationOTPViewModel.createddate = obj.createddate;
                    objCustomerRegistrationOTPViewModel.isdeleted = obj.isdeleted;
                    objCustomerRegistrationOTPViewModel.isactive = obj.isactive;
                     objCustomerRegistrationOTPViewModel.otpno = no;
                    return Ok(objCustomerRegistrationOTPViewModel);
                }


            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
    }
}
