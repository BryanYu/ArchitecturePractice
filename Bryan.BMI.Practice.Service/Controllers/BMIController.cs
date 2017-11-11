using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bryan.BMI.Practice.Service.Controllers
{
    public class BMIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetBMI(float height,float weight)
        {
            var bmi = new BMI.Practice.BO.BMI()
            {
                Height = height,
                Weight = weight
            };

            return Ok(bmi.Result);
        }
    }
}
