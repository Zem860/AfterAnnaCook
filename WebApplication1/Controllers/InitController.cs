using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class InitController : ApiController
    {
        private HW1 db = new HW1();

        [HttpGet]
        [Route("api/init/getCounties")]
        public IHttpActionResult getCounties()
        {
            var counties = db.Counties.Select(c => new {c.Id, c.CountyName}).ToList();
            return Ok(counties);
        }

        [HttpGet]
        [Route("api/init/getDistricts")]
        public IHttpActionResult getDistricts(int id)
        {
            List<string> districts = db.Districts.Where(d=>d.CountyId == id).Select(d => d.DistrictName).ToList();
            return Ok(districts);
        }
    }
}
