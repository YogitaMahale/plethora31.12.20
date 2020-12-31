using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using plathora.Entity;
using plathora.Services;
using Microsoft.AspNetCore.Authorization;

using plathora.Utility;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace plathora.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]


    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        
        private readonly ICustomerRegistrationservices _CustomerRegistrationservices;
        public CustomerController(ICustomerRegistrationservices CustomerRegistrationservices)
        {
            _CustomerRegistrationservices = CustomerRegistrationservices;
             
        }

        [HttpGet]
      public IActionResult Get()
        {
            var customer = _CustomerRegistrationservices.GetAll().ToList();
            if(customer.Count==0)
            {
                return NotFound("No List Found");
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer= _CustomerRegistrationservices.GetById(id);
            if (customer!=null)
            {
                return Ok(customer);
              
            }
            else
            {
                return NotFound("No Record Found");

            }
        }
        // ([FromBody] tblemployee p)
//        id, name, profilephoto, address, mobileno1, mobileno2, emailid1, latitude, longitude, password, gender
//, DOB, createddate, isdeleted, isactive

        [HttpPost]
        //public IActionResult Post([FromBody] string name, [FromBody] string address)
        public IActionResult Post(string name,string address)
        {
            CustomerRegistration c = new CustomerRegistration();
            c.id = 0;
            c.name = name;
            c.profilephoto = "a";
            c.address = address;
            c.mobileno1 = "a";
            c.mobileno2 = "a";
            c.emailid1 = "a";
            c.latitude = "a";
            c.longitude = "a";
            c.password = "a";
            c.gender = "Male";
            c.DOB = DateTime.UtcNow;
            c.createddate = DateTime.UtcNow;
            c.isdeleted = false;

            c.isactive = false;


            _CustomerRegistrationservices.CreateAsync(c);


            //if (customer != null)
            //{
            return Ok("Save");

            //}
            //else
            //{
            //    return NotFound("No Record Found");

            //}
        }

    }
}
