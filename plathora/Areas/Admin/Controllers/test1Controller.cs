using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using appFoodDelivery.Services.Implementation;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plathora.Entity;
using plathora.Models;
using plathora.Persistence;
using plathora.Services;

namespace plathora.Controllers
{
    [Area("Admin")]
    public class test1Controller : Controller
    {
        private ISP_Call _sP_Call;
        private readonly ISubscribeServices _subscribeServices;
        private readonly ApplicationDbContext _db;
        private readonly SignInManager<IdentityUser> _signInManager;



        //private readonly SignInManager<IdentityUser> _signInManager;
        public test1Controller(ISubscribeServices subscribeServices, ISP_Call sP_Call, ApplicationDbContext db, SignInManager<IdentityUser> signInManager)
        {
            _sP_Call = sP_Call;
            _subscribeServices = subscribeServices;
            _db = db;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string  Add(string email)
        {
            Subscribe obj = new Subscribe();
            obj.id = 0;
            obj.Email = email;


            var parameter = new DynamicParameters();
            parameter.Add("@Email", email);

            _sP_Call.Execute("SubscribeSave", parameter);
            
            return "complete";
        }
        [HttpPost]
        public async Task<string> MobileView(string mobileNo)
        {
            var userList = await _db.applicationUsers.Where(x=>x.UserName==mobileNo).FirstOrDefaultAsync();
            if(userList==null)
            {
            String no = null;
            Random random = new Random();
            for (int i = 0; i <1; i++)
            {
                int n = random.Next(1000, 9999);
                no += n.ToString("D4") + "";
            }
                #region "sms"
                try
                {

                    string Msg = "OTP :" + no + ".  Please Use this OTP.This is usable once and expire in 10 minutes";

                    string OPTINS = "STRLIT";

                    string type = "3";
                    string strUrl = "https://www.bulksmsgateway.in/sendmessage.php?user=ezacus&password=" + "Bingo@5151" + "&message=" + Msg.ToString() + "&sender=" + OPTINS + "&mobile=" + mobileNo + "&type=" + 3;

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
                return no;
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(mobileNo, "Password@1",false, lockoutOnFailure: false);
            
                return "Login";
            }

            

           
        }

        [HttpPost]
        public string    getOTPNoSubmit(string mobileNo)
        {
            //E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\plathora final\plathora\Areas\Identity\Pages\Account\Register.cshtml
           // return LocalRedirect("/Identity/Pages/Account/Login");
           // return RedirectToPage("/Account/Login", new { area = "Identity" });
            //string url = "https://localhost:44322/Identity/Account/Register";
            //return Redirect(url);

             return "dsf";
            //return View();
        }
        
        [HttpGet]
        public ActionResult testt()
        {
            //E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\plathora final\plathora\Areas\Identity\Pages\Account\Register.cshtml
            //return LocalRedirect("/Identity/Pages/Account/Register");
            //return RedirectToPage("/Account/Register", new { area = "Identity" });
            // return RedirectToPage("/account/Register");
            // return "dsf";
            //return View();

            return RedirectToAction("Index", "Home");

        }


    }
}