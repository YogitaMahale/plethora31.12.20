using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plathora.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using plathora.Entity;
using plathora.Persistence;
using Microsoft.EntityFrameworkCore;
using plathora.Models;
using plathora.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;
namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    [Produces("application/json")]
    [Route("api/testt")]
    public class testtController : Controller
    {
        
       // private readonly ApplicationDbContext _context;
       private readonly ICustomerRegistrationservices CustomerRegistrationservices;
        public testtController(ICustomerRegistrationservices _CustomerRegistrationservices)
        {
            CustomerRegistrationservices = _CustomerRegistrationservices;
        }
        //public testtController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        [Route("GetCustomer")]
        public  async Task<IActionResult> GetCustomer()
        {
            try
            {
                IEnumerable<CustomerRegistration> c =   CustomerRegistrationservices.GetAll(); 
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
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> save([FromBody] emp obj)
        {
            var empo = obj;

            if (ModelState.IsValid)
            {
                try
                {

                    var postId = 0;

                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerRegistrationDto viewModel)
        {
            var model = viewModel;
            
            //            id, name, profilephoto, address, mobileno1, mobileno2, emailid1, latitude, longitude, password, 
            //--gender, DOB, createddate, isdeleted, isactive
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok();
                    //var postId = 0;

                    //if (postId > 0)
                    //{
                    //    return Ok(postId);
                    //}
                    //else
                    //{
                    //    return NotFound();
                    //}
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        //[HttpPost]
        //[Route("AddCustomer")]
        //public async Task<IActionResult> AddCustomer(string name, string address, string mobileno, string password, string gender)
        //{

        //    CustomerRegistration c1 = new CustomerRegistration();
        //    c1.name = name;
        //    c1.profilephoto = "";
        //    c1.address = address;
        //    c1.mobileno1 = mobileno;
        //    c1.mobileno2 = "";
        //    c1.emailid1 = "";
        //    c1.latitude = "";
        //    c1.longitude = "";
        //    c1.password = password;
        //    c1.gender = gender ;
        //    //c1.DOB = name1;
        //    c1.createddate = DateTime.UtcNow;
        //    c1.isdeleted = false;
        //    c1.isactive = false;

        //    //            id, name, profilephoto, address, mobileno1, mobileno2, emailid1, latitude, longitude, password, 
        //    //--gender, DOB, createddate, isdeleted, isactive


        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            var postId = 0;

        //            if (postId > 0)
        //            {
        //                return Ok(postId);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }

        //    }

        //    return BadRequest();
        //}
        //[HttpPost]
        //[Route("AddCustomer")]
        //public async Task<IActionResult> AddCustomer(string name1 ,string add)
        //{
        //    CustomerRegistration c = CustomerRegistrationservices.GetById(1);
        //    c.name = name1;
        //    c.address = add;

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var postId = await CustomerRegistrationservices.CreateAsync(c);
        //            if (postId > 0)
        //            {
        //                return Ok(postId);
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //        catch (Exception)
        //        {

        //            return BadRequest();
        //        }

        //    }

        //    return BadRequest();
        //}

    }
}
