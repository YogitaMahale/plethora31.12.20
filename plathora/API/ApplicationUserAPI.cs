
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Models;
using plathora.Models.Dtos;
using plathora.Persistence;
using plathora.Services;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using plathora.Utility;
using Dapper;
using System.Net.Mail;
using System.Text;
using System.Net.Mime;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;

namespace plathora.API
{
    [Route("ApplicationUser")]
    public class ApplicationUserAPI : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IBusinessOwnerRegiServices _businessOwnerRegiServices;
        private readonly ISP_Call _sP_Call;
        private readonly IAboutUsServices _AboutUsServices;
        private readonly IAffilatePackageServices _AffilatePackageServices;
        private readonly IMembershipServices _MembershipServices;
        private readonly Microsoft.AspNetCore.Identity.UI.Services.IEmailSender _emailSender;
        public ApplicationUserAPI(IWebHostEnvironment hostingEnvironment, UserManager<IdentityUser> userManager, ApplicationDbContext db, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IBusinessOwnerRegiServices businessOwnerRegiServices, ISP_Call sP_Call, IAboutUsServices AboutUsServices, IAffilatePackageServices AffilatePackageServices, IMembershipServices MembershipServices, IEmailSender emailSender)
        {
            _userManager = userManager ;
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _businessOwnerRegiServices = businessOwnerRegiServices;
            _sP_Call = sP_Call;
            _AboutUsServices = AboutUsServices;
            _AffilatePackageServices = AffilatePackageServices;
            _MembershipServices = MembershipServices;
            _emailSender = emailSender;

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
              

                ApplicationUserViewModelDtos objApplicationUserViewModelDtos = new ApplicationUserViewModelDtos();
                //AffiltateRegistration obj = _AffiltateRegistrationService.GetAll().Where(x => x.mobileno1 == mobileno && x.isdeleted == false).FirstOrDefault();
                var obj = _db.applicationUsers.FirstOrDefault(x => x.PhoneNumber == mobileno);
              //  var businessSrNo1 = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == obj.Id).FirstOrDefault().id;
                if (obj != null)
                {

                    objApplicationUserViewModelDtos.Id = obj.Id;
                    objApplicationUserViewModelDtos.name = obj.name;
                    objApplicationUserViewModelDtos.profilephoto = obj.profilephoto;
                    objApplicationUserViewModelDtos.PhoneNumber = obj.PhoneNumber;
                    objApplicationUserViewModelDtos.mobileno2 = obj.mobileno2;
                    objApplicationUserViewModelDtos.Email = obj.Email; ;
                    objApplicationUserViewModelDtos.emailid2 = obj.emailid2;
                    objApplicationUserViewModelDtos.adharcardno = obj.adharcardno;
                    objApplicationUserViewModelDtos.adharcardphoto = obj.adharcardno;
                    objApplicationUserViewModelDtos.pancardno = obj.pancardno;
                    objApplicationUserViewModelDtos.pancardphoto = obj.pancardphoto;
                    objApplicationUserViewModelDtos.gender = obj.gender;
                    objApplicationUserViewModelDtos.DOB = obj.DOB;
                    //objApplicationUserViewModelDtos.house = obj.house;
                    //objApplicationUserViewModelDtos.landmark = obj.landmark;
                    //objApplicationUserViewModelDtos.street = obj.street;
                    //objApplicationUserViewModelDtos.cityid = obj.cityid;
                    //objApplicationUserViewModelDtos.zipcode = obj.zipcode;
                    //objApplicationUserViewModelDtos.latitude = obj.latitude;
                    //objApplicationUserViewModelDtos.longitude = obj.longitude;
                    //objApplicationUserViewModelDtos.companyName = obj.companyName;
                    //objApplicationUserViewModelDtos.designation = obj.designation;
                    //objApplicationUserViewModelDtos.gstno = obj.gstno;
                    //objApplicationUserViewModelDtos.Website = obj.Website;
                    objApplicationUserViewModelDtos.bankname = obj.bankname;
                    objApplicationUserViewModelDtos.accountname = obj.accountname;
                    objApplicationUserViewModelDtos.accountno = obj.accountno;
                    objApplicationUserViewModelDtos.ifsccode = obj.ifsccode;
                    objApplicationUserViewModelDtos.branch = obj.branch;
                    objApplicationUserViewModelDtos.passbookphoto = obj.passbookphoto;
                    //objApplicationUserViewModelDtos.Membershipid = obj.Membershipid;
                    //objApplicationUserViewModelDtos.amount = obj.amount;
                    objApplicationUserViewModelDtos.otpno = no;
                    var obj1 = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == obj.Id).FirstOrDefault();
                    if (obj1 == null)
                    {
                        objApplicationUserViewModelDtos.businessSrNo = "";
                    }
                    else
                    {
                        objApplicationUserViewModelDtos.businessSrNo = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == obj.Id).FirstOrDefault().id.ToString();
                    }

                    return Ok(objApplicationUserViewModelDtos);
                }
                else
                {
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
                    objApplicationUserViewModelDtos.otpno = no;
                    return Ok(objApplicationUserViewModelDtos);
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }

        private bool SendMail(string Name, string Email,string userpassword,string uniqueId,string phonenumber)
        {

            // SendMail(name, model.emailid1, model.password, affilatereg.uniqueId, affilatereg.PhoneNumber);
            string email = "info@tingtongindia.com";
            string password = "Plethora@123";

            //string email = "demo@moryatools.com";
            //string password = "vsys@2017";





            bool send = false;
            MailMessage mail = new MailMessage();
            mail.To.Add(Email);
           
            mail.From = new MailAddress(email, "Registration");
            mail.Subject = "Affilate Registration Details";
            StringBuilder strBul = new StringBuilder("<div>");
            strBul = strBul.Append("<div>Dear " + Name + ",</div>");
            strBul = strBul.Append("<br />");
            //strBul = strBul.Append("<div>Your Account Details</div>");
            //strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>We are pleased to inform you that your Tingtong account with Affilate  CODE -: &nbsp;"+uniqueId+" has been Created successfully.</div>");
            strBul = strBul.Append("<br />");
            //strBul = strBul.Append("<div>Password -: &nbsp; " + Password + "</div>");
            //strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>Please use the information given below to login your online trading account</div>");
            strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>User Name / User ID -: &nbsp; " + phonenumber + "</div>");
            strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>Transaction Password -: &nbsp; " + userpassword + "</div>");
            strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>Feel free to call us or email us if you need any other information.</div>");
            strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>Assuring you of our best services at all times.</div>");
            strBul = strBul.Append("<br />");
            strBul = strBul.Append("<div>Best Regards,</div>");
            strBul = strBul.Append("<div>Team TingTong</div>");
            strBul = strBul.Append("<div>Mail Us: suppport@tingtongindia.com</ div>");
            strBul = strBul.Append("</div>");
            mail.Body = strBul.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "103.250.184.62";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(email, password);
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (Exception ex)
            {
                send = false;
              //  ErrHandler.writeError(ex.Message, ex.StackTrace);
            }
            return send;
        }
        private AlternateView Mail_Body(string Name, string bankname, string accountname, string accountno, string uniqueId, string pancardphoto, string passbookphoto)
        {
            string pancardphotopath = _hostingEnvironment.WebRootPath +(pancardphoto.Replace('/','\\'));
            string passbookphotopath = _hostingEnvironment.WebRootPath + (passbookphoto.Replace('/', '\\'));
            // string path = Server.MapPath(pancardphoto);
            LinkedResource pancardphotoImg = new LinkedResource(pancardphotopath, MediaTypeNames.Image.Jpeg);
            pancardphotoImg.ContentId = "MyImage";

            LinkedResource passbookphotoImg = new LinkedResource(passbookphotopath, MediaTypeNames.Image.Jpeg);
            passbookphotoImg.ContentId = "MyImage1";

            

            StringBuilder str = new StringBuilder();
            str = str.Append("<div>Hello Team,</div>");
            str = str.Append("<br />");
            str = str.Append("<div>Hope you are doing well, </div>");
            str = str.Append("<br />");
            str = str.Append("<div>We want create label for following account</div>");
            str = str.Append("<br />");
            //str = str.Append("<div>Company  Merchant id: plethoraworldwide@gmail.com</div>");
            //str = str.Append("<br />");


            //str = str.Append("<div>Person Name -: &nbsp; " + Name + "</div>");
            //str = str.Append("<br />");
            //str = str.Append("<div>Bank Name -: &nbsp; " + bankname + "</div>");
            //str = str.Append("<br />");
            //str = str.Append("<div>Account Name -: &nbsp; " + accountname + "</div>");
            //str = str.Append("<br />");
            //str = str.Append("<div>Account No -: &nbsp; " + accountno + "</div>");
            //str = str.Append("<br />");
            //str = str.Append("<div>Label: -: &nbsp; " + uniqueId + "</div>");
            //str = str.Append("<br />");
            str = str.Append(@"            
   
               <table class='table table - condensed'>
                <tr>  
                    <td> " + "Company  Merchant ID : " + @" 
                    </td>  
                  
                    <td>  " + "plethoraworldwide@gmail.com" + @"                       
                    </td>  
                </tr>
                   <tr>  
                    <td> " + "Bank Name : " + @"  
                    </td>  
                  
                    <td>  " + bankname + @"                       
                    </td>  
                </tr>
                     <tr>  
                    <td> " + "Account Name : " + @"  
                    </td>  
                  
                    <td>  " + accountname + @"                       
                    </td>  
                </tr>
                       <tr>  
                    <td> " + "Account No : " + @"  
                    </td>  
                  
                    <td>  " + accountno + @"                       
                    </td>  
                </tr>

                 <tr>  
                    <td> " + "Account No : " + @"  
                    </td>  
                  
                    <td> " + accountno + @"                       
                    </td>  
                </tr>
                     <tr>  
                    <td> " + "Label : " + @"  
                    </td>  
                  
                    <td>  " + uniqueId + @"                       
                    </td>  
                </tr>
                <tr>  
                    <td> " + "Pancard Photo : " + @"  
                    </td>  
                  
                    <td>  
                      <img src=cid:MyImage  id='img' alt='' width='250px' height='100px'/>   
                    </td>  
                </tr>
                <tr>  
                    <td> " + "Passbook Photo : " + @"  
                    </td>  
                   
                    <td>  
                      <img src=cid:MyImage1  id='img' alt='' width='250px' height='100px'/>   
                    </td>  
                </tr>
           </table> 

            ");
            str = str.Append("<div>Thank you.</div>");
            AlternateView AV =
             AlternateView.CreateAlternateViewFromString(str.ToString(), null, MediaTypeNames.Text.Html);

            AV.LinkedResources.Add(pancardphotoImg);
            AV.LinkedResources.Add(passbookphotoImg);
            return AV;
        }
        private bool SendMailToEasebuzz(string Name, string bankname, string accountname,string accountno, string uniqueId, string pancardphoto,string passbookphoto)
        {

            string email = "info@tingtongindia.com";
            string password = "Plethora@123";

            

            //string email = "demo@moryatools.com";
            //string password = "vsys@2017";
            bool send = false;
            MailMessage mail = new MailMessage();
            //mail.To.Add("mahaleyogita233@gmail.com");
            mail.To.Add("support@easebuzz.com");
            mail.From = new MailAddress(email, "Label ID Creation");
            mail.Subject = "Label Creation";
            StringBuilder strBul = new StringBuilder("<div>");
           
            mail.AlternateViews.Add(Mail_Body(Name, bankname, accountname, accountno, uniqueId, pancardphoto, passbookphoto));
            
           
            strBul = strBul.Append("</div>");
            mail.Body = strBul.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "103.250.184.62";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(email, password);
            try
            {
                smtp.Send(mail);
                send = true;
            }
            catch (Exception ex)
            {
                send = false;
                //  ErrHandler.writeError(ex.Message, ex.StackTrace);
            }
            return send;
        }



        //[HttpPost]
        //[Route("SaveUser")]
        //public async Task<IActionResult> SaveUser(ApplicationUserSaveModelDtos model)
        //{

        //    var checkduplicate = _db.applicationUsers.Where(x => x.PhoneNumber == model.mobileno1).FirstOrDefault();
        //    string affilateID = "";
        //    if (model.registerbyAffilateID==null)
        //    {
        //        var parameter = new DynamicParameters();
        //        //parameter.Add("@businessid", businessid);
        //        var obj = _sP_Call.OneRecord<getAffilateIdViewModel>("getAffilateId", null );
        //       if(obj==null)
        //        {

        //        }
        //        else
        //        {
        //            affilateID = obj.id;
        //        }


        //    }
        //    else
        //    {
        //        affilateID = model.registerbyAffilateID;
        //    }

        //    if (checkduplicate == null)
        //    {
        //        string rolename = string.Empty;
        //        if(model.usertype.ToUpper().Trim()== "AFFILATE".Trim())
        //        {
        //            rolename = SD.Role_Affilate;
        //        }
        //       else if (model.usertype.ToUpper().Trim() == "CUSTOMER".Trim())
        //        {
        //            rolename = SD.Role_Customer;

        //        }
        //        string uniqueNo = _AboutUsServices.generateRandomNo(model.name.Substring(0, 3));
        //        //AffiltateRegistration obj = new AffiltateRegistration();

        //        var user = new ApplicationUser
        //        {


        // name = model.name,
        // MiddleName=model.MiddleName,
        // LastName=model.LastName,
        //            UserName=model.mobileno1,
        //// profilephoto = model.pro
        // PhoneNumber = model.mobileno1,        
        // Email  = model.emailid1,
        // emailid2 = model.emailid2, 
        // gender = model.gender,
        // DOB = model.DOB,
        // createddate =DateTime.Now,
        //registerbyAffilateID= affilateID,
        //            AffilatePackageid =model.AffilatePackageid,
        //            PaymentStatus=model.PaymentStatus,
        //            PaymentAmount=model.PaymentAmount,
        //            TransactionId=model.TransactionId,
        //            uniqueId=uniqueNo


        //        };





        //        try
        //        {

        //                var result = await _userManager.CreateAsync(user, model.password);
        //                if (result.Succeeded)
        //                {

        //                    if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
        //                    {
        //                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
        //                    }

        //                    if (!await _roleManager.RoleExistsAsync(SD.Role_Affilate))
        //                    {
        //                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Affilate));
        //                    }
        //                    if (!await _roleManager.RoleExistsAsync(SD.Role_Customer))
        //                    {
        //                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
        //                    }
        //                    //await _userManager.AddToRoleAsync(user, SD.Role_Admin);
        //                    if (model.usertype.ToUpper().Trim() == "AFFILATE".Trim())
        //                    {
        //                        await _userManager.AddToRoleAsync(user, SD.Role_Affilate);
        //                    }
        //                    else
        //                    {
        //                        await _userManager.AddToRoleAsync(user, SD.Role_Customer);
        //                    }


        //                //if (model.usertype.ToUpper().Trim() == "AFFILATE".Trim())
        //                //{
        //                //    int membershipid = _AffilatePackageServices.getbyid((int)model.AffilatePackageid).membershipid;
        //                //    string pkgname = _MembershipServices.GetById(membershipid).membershipName;
        //                //    string name = model.name + " " + model.MiddleName + " " + model.LastName;
        //                //    SendMail(name, model.emailid1, model.password, uniqueNo, model.PaymentStatus,model.PaymentAmount.ToString(),model.TransactionId, pkgname);
        //                //}
        //                else if (model.usertype.ToUpper().Trim() == "CUSTOMER".Trim())
        //                {
        //                    rolename = SD.Role_Customer;

        //                }

        //                //var objj = _db.applicationUsers.Where(x=>x.Id==user.Id).FirstOrDefault();
        //                return Ok(user);
        //                }
        //                return Ok();





        //        }
        //        catch (Exception a)
        //        {

        //            string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
        //            return BadRequest(myJson);

        //        }


        //    }
        //    else
        //    {

        //        string myJson = "{\"Message\": " + "\"Duplicate Mobile No\"" + "}";
        //        return BadRequest(myJson);

        //    }


        //}
        [HttpPost]
        [Route("SaveUser")]
        public async Task<IActionResult> SaveUser(ApplicationUserSaveModelDtos model)
        {

            var checkduplicate = _db.applicationUsers.Where(x => x.PhoneNumber == model.mobileno1).FirstOrDefault();
            string affilateID = "";
            if (model.registerbyAffilateID == null)
            {
                var parameter = new DynamicParameters();
                //parameter.Add("@businessid", businessid);
                var obj = _sP_Call.OneRecord<getAffilateIdViewModel>("getAffilateId", null);
                if (obj == null)
                {

                }
                else
                {
                    affilateID = obj.id;
                }


            }
            else
            {
                affilateID = model.registerbyAffilateID;
            }

            if (checkduplicate == null)
            {
                string rolename = string.Empty;
                if (model.usertype.ToUpper().Trim() == "AFFILATE".Trim())
                {
                    rolename = SD.Role_Affilate;
                }
                else if (model.usertype.ToUpper().Trim() == "CUSTOMER".Trim())
                {
                    rolename = SD.Role_Customer;

                }
                string uniqueNo = _AboutUsServices.generateRandomNo(model.name.Substring(0, 3));
                //AffiltateRegistration obj = new AffiltateRegistration();

                var user = new ApplicationUser
                {


                    name = model.name,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    UserName = model.mobileno1,
                    // profilephoto = model.pro
                    PhoneNumber = model.mobileno1,
                    Email = model.emailid1,
                    emailid2 = model.emailid2,
                    gender = model.gender,
                    DOB = model.DOB,
                    createddate = DateTime.Now,
                    registerbyAffilateID = affilateID,
                    AffilatePackageid = model.AffilatePackageid,
                    PaymentStatus = model.PaymentStatus,
                    PaymentAmount = model.PaymentAmount,
                    TransactionId = model.TransactionId,
                    uniqueId = uniqueNo


                };





                try
                {

                    var result = await _userManager.CreateAsync(user, model.password);
                    if (result.Succeeded)
                    {

                        if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                        }

                        if (!await _roleManager.RoleExistsAsync(SD.Role_Affilate))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Affilate));
                        }
                        if (!await _roleManager.RoleExistsAsync(SD.Role_Customer))
                        {
                            await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                        }
                        //await _userManager.AddToRoleAsync(user, SD.Role_Admin);
                        if (model.usertype.ToUpper().Trim() == "AFFILATE".Trim())
                        {
                            await _userManager.AddToRoleAsync(user, SD.Role_Affilate);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, SD.Role_Customer);
                        }


                        //if (model.usertype.ToUpper().Trim() == "AFFILATE".Trim())
                        //{
                        //    int membershipid = _AffilatePackageServices.getbyid((int)model.AffilatePackageid).membershipid;
                        //    string pkgname = _MembershipServices.GetById(membershipid).membershipName;
                        //    string name = model.name + " " + model.MiddleName + " " + model.LastName;
                        //    SendMail(name, model.emailid1, model.password, uniqueNo, model.PaymentStatus, model.PaymentAmount.ToString(), model.TransactionId, pkgname);
                        //}
                        //else if (model.usertype.ToUpper().Trim() == "CUSTOMER".Trim())
                        //{
                        //    rolename = SD.Role_Customer;

                        //}

                        //var objj = _db.applicationUsers.Where(x=>x.Id==user.Id).FirstOrDefault();
                        return Ok(user);
                    }
                    return Ok();





                }
                catch (Exception a)
                {

                    string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                    return BadRequest(myJson);

                }


            }
            else
            {

                string myJson = "{\"Message\": " + "\"Duplicate Mobile No\"" + "}";
                return BadRequest(myJson);

            }


        }

        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> updateUser(ApplicationUserEditModelDtos model)
        {

            var checkduplicate = _db.applicationUsers.Where(x => x.PhoneNumber == model.mobileno1 && x.Id == model.id);

            if (checkduplicate != null)
            {
                try
                {
                    var affilatereg = _db.applicationUsers.FirstOrDefault(u => u.Id == model.id);
                    if (affilatereg == null)
                    {
                        return NotFound();
                    }

                    affilatereg.Id = model.id;
                    affilatereg.name = model.FirstName;
                    affilatereg.LastName = model.LastName;
                    affilatereg.MiddleName = model.MiddleName;
                    //profilephoto,
                    affilatereg.PhoneNumber = model.mobileno1;
                    affilatereg.mobileno2 = model.mobileno2;
                    affilatereg.Email = model.emailid1;
                    affilatereg.emailid2 = model.emailid2;
                    affilatereg.adharcardno = model.adharcardno;
                    //adharcardphoto,
                    affilatereg.pancardno = model.pancardno;
                    // pancardphoto,

                    affilatereg.gender = model.gender;
                    affilatereg.DOB = model.DOB;
                    //   affilatereg.createddate = model.createddate;
                    affilatereg.house = model.house;
                    affilatereg.landmark = model.landmark;
                    affilatereg.street = model.street;
                    affilatereg.cityid = model.cityid;
                    //affilatereg.companyName = model.companyName;
                    //affilatereg.designation = model.designation;
                    //affilatereg.gstno = model.gstno;
                    //affilatereg.Website = model.Website;
                    affilatereg.zipcode = model.zipcode;



                    affilatereg.bankname = model.bankname;
                    affilatereg.accountname = model.accountname;

                    affilatereg.accountno = model.accountno;
                    affilatereg.ifsccode = model.ifsccode;
                    affilatereg.branch = model.branch;
                    //affilatereg.Membershipid = model.Membershipid;
                    //affilatereg.amount = model.amount;
                    affilatereg.latitude = model.latitude;
                    affilatereg.longitude = model.longitude;



                    if (model.profilephoto != null && model.profilephoto.Length > 0)
                    {

                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\user\profilephoto";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.profilephoto));
                        affilatereg.profilephoto = "/uploads/user/profilephoto/" + fileName;

                    }
                    if (model.adharcardphoto != null && model.adharcardphoto.Length > 0)
                    {

                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\user\adharcardphoto";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.adharcardphoto));
                        affilatereg.adharcardphoto = "/uploads/user/adharcardphoto/" + fileName;

                    }
                    if (model.pancardphoto != null && model.pancardphoto.Length > 0)
                    {


                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\user\pancardphoto";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.pancardphoto));
                        affilatereg.pancardphoto = "/uploads/user/pancardphoto/" + fileName;

                    }
                    if (model.passbookphoto != null && model.passbookphoto.Length > 0)
                    {

                        string fileName = Guid.NewGuid().ToString();
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + ".jpg";
                        var folderPath = _hostingEnvironment.WebRootPath + @"\uploads\user\passbookphoto";
                        if (!System.IO.Directory.Exists(folderPath))
                        {
                            System.IO.Directory.CreateDirectory(folderPath);
                        }
                        System.IO.File.WriteAllBytes(Path.Combine(folderPath, fileName), Convert.FromBase64String(model.passbookphoto));
                        affilatereg.passbookphoto = "/uploads/user/passbookphoto/" + fileName;

                    }
                    var result = await _userManager.UpdateAsync(affilatereg);
                    if (result.Succeeded)
                    {


                        var parameter = new DynamicParameters();
                        parameter.Add("@uniqueId", affilatereg.uniqueId);

                       _sP_Call.Execute("LevelWiseCommissionRegistration", parameter);
                        //-----------------
                        if (model.usertype.ToUpper().Trim() == "AFFILATE".Trim())
                        {
                            
                            //int membershipid = _AffilatePackageServices.getbyid((int)affilatereg.AffilatePackageid).membershipid;
                            //string pkgname = _MembershipServices.GetById(membershipid).membershipName;
                            string name = model.FirstName + " " + model.MiddleName + " " + model.LastName;
                            SendMail(name, model.emailid1,model.password, affilatereg.uniqueId,affilatereg.PhoneNumber);
                           
                           // SendMailToEasebuzz(name, model.bankname, model.accountname, affilatereg.accountno, affilatereg.uniqueId, affilatereg.pancardphoto,affilatereg.passbookphoto);
                        }
                        return Ok(affilatereg);
                    }
                }
                catch(Exception obj)
                {

                    string ff = obj.Message.ToString();
                }
              

            }
            else
            {
                string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                return NotFound(myJson);
            }

            return BadRequest();
        }
       
        [HttpGet]
        [Route("UserLogin")]
        public async Task<IActionResult> UserLogin(string mobileNo, string password)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(mobileNo, password,true,  lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // var obj = _db.applicationUsers.Where(x => x.PhoneNumber == mobileNo);

                    var parameter = new DynamicParameters();
                    parameter.Add("@mobileno", mobileNo);

                    var obj = _sP_Call.OneRecord<AffilateLoginViewModel>("affilateLogin", parameter);

                    return Ok(obj);
                }
               
                if (result.IsLockedOut)
                {
                     
                    string myJson = "{\"Message\": " + "\"User account locked out.\"" + "}";
                    return BadRequest(myJson);
                }
                else
                {
                   
                    string myJson = "{\"Message\": " + "\"Invalid login attempt.\"" + "}";
                    return BadRequest(myJson);
                }

                

            }
            catch
            {
                string myJson = "{\"Message\": " + "\"Bad Request\"" + "}";
                return BadRequest(myJson);
            }
        }
        [HttpPut]
        [Route("updateCustomerDeviceId")]
        public async Task<IActionResult> updateCustomerDeviceId([FromUri] string deviceId, [FromUri] string  id)
        {
            var customer = _db.applicationUsers.Where(x => x.Id == id).FirstOrDefault();
            if (customer == null)
            {
                string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                return NotFound(myJson);
            }
            else
            {
                customer.deviceid = deviceId;
                var result = await _userManager.UpdateAsync(customer);
                if (result.Succeeded)
                {
                    return Ok(customer);
                }              
                else
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound (myJson);
                }
            }



            return BadRequest();
        }


        [HttpGet]
        [Route("checkUniqueId")]
        public async Task<IActionResult> checkUniqueId(string uniqueId)
        {
            try
            {

                

               
                var obj = _db.applicationUsers.FirstOrDefault(x => x.uniqueId == uniqueId);
                //  var businessSrNo1 = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == obj.Id).FirstOrDefault().id;
                if (obj != null)
                {

                    string myJson = "{\"Message\": " + "\"Record Found\"" + "}";
                    return Ok(myJson);
                }
                else
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("affilateList")]
        public async Task<IActionResult> affilateList(string uniqueid)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("@uniqueId", uniqueid);


                var obj = _sP_Call.List<AffilateListSPViewModel>("AffilateListSP", parameter);

                //  var businessSrNo1 = _businessOwnerRegiServices.GetAll().Where(x => x.customerid == obj.Id).FirstOrDefault().id;
                if (obj != null)
                {

                    
                    return Ok(obj);
                }
                else
                {

                    string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson);
                }

            }
            catch (Exception obj)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("BusinessListbyAffilateId")]
        public async Task<IActionResult> BusinessListbyAffilateId(string uniqueId)
        {
            try
            {


                var parameter = new DynamicParameters();
                parameter.Add("@registerbyAffilateUniqueId", uniqueId);

                var obj = _sP_Call.List<BusinessOwnerRegiListViewModel>("BusinessOwnerRegiList", parameter);
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
        [Route("advertisementByAffilateUniqueId")]
        public async Task<IActionResult> advertisementByAffilateUniqueId(string uniqueId)
        {
            try
            {


                var parameter = new DynamicParameters();
                parameter.Add("@registerbyAffilateUniqueId", uniqueId);

                var obj = _sP_Call.List<advertisementInfoViewModel>("advertisementByAffilateUniqueId", parameter);
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
        [Route("commisionbyAffilateUniqueId")]
        public async Task<IActionResult> commisionbyAffilateUniqueId(string uniqueId)
        {
            try
            {


                var parameter = new DynamicParameters();
                parameter.Add("@registerbyAffilateUniqueId", uniqueId);

                var obj = _sP_Call.List<AffilateCommisionViewModel>("AffilateCommision", parameter);
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
        [Route("updateUserLoginStatus")]
        public async Task<IActionResult> updateUserLoginStatus(string userId,bool status)
        {

            
                try
                {
                    var affilatereg = _db.applicationUsers.FirstOrDefault(u => u.Id == userId);
                    if (affilatereg == null)
                    {
                       string myJson1 = "{\"Message\": " + "\"Not Found\"" + "}";
                    return NotFound(myJson1);
                    }

                affilatereg.loginStatus = status;
                affilatereg.logintime = DateTime.Now;


                var result = await _userManager.UpdateAsync(affilatereg);
                    if (result.Succeeded)
                    {
                        return Ok(affilatereg);
                    }
                }
                catch (Exception obj)
                {

                    string ff = obj.Message.ToString();
                }




            string myJson = "{\"Message\": " + "\"Not Found\"" + "}";
            return BadRequest(myJson);
        }

        [System.Web.Mvc.HttpGet]
        [Route("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string mobileNo)
        {


            try
            {
                var user = await _userManager.FindByNameAsync(mobileNo);
                //if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                if (user == null)
                {

                    return NotFound("Not Found");
                }

                 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                await _emailSender.SendEmailAsync(
                    user.Email,
                    "Reset Password",
                    $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                string myJson = "{\"Message\": " + "\"Please check your email to reset your password.\"" + "}";
                return BadRequest(myJson);
            }
            catch (Exception obj)
            {

                string ff = obj.Message.ToString();
            }
            return BadRequest("Bad Request");




        }


    }
}
