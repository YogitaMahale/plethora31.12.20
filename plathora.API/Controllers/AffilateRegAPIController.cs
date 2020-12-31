using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace plathora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffilateRegAPIController : ControllerBase
    {
       // public HttpResponseMessage GET()
       // {
            //try
            //{
            //    string gender = "all";
            //    switch (gender.ToLower())
            //    {
            //        case "all":
            //            return Request.CreateResponse(HttpStatusCode.OK, db.tblemployees.ToList());
            //        case "male":
            //            return Request.CreateResponse(HttpStatusCode.OK, db.tblemployees.Where(x => x.gender.ToLower() == gender.ToLower()).ToList());
            //        case "female":
            //            return Request.CreateResponse(HttpStatusCode.OK, db.tblemployees.Where(x => x.gender.ToLower() == gender.ToLower()).ToList());
            //        default:
            //            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Enter proper gender value");

            //    }
            //}
            //catch (Exception obj)
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Enter proper gender value");

            //}


      //  }
    }
}