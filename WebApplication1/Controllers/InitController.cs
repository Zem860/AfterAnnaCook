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
            var counties = db.Counties.Select(c => new { c.Id, c.CountyName }).ToList();
            return Ok(counties);
        }

        [HttpGet]
        [Route("api/init/getDistricts")]
        public IHttpActionResult getDistricts(int id)
        {
            var districts = db.Districts.Where(d => d.CountyId == id).Select(d => new { d.Id, d.DistrictName }).ToList();
            return Ok(districts);
        }
        [HttpGet]
        [Route("api/init/getPostalCode")]
        public IHttpActionResult getPostalCode(int id)
        {
            var postalCode = db.Districts.Where(d => d.Id == id).Select(d => d.PostalCode).FirstOrDefault();
            if (postalCode == null)
            {
                return NotFound();
            }
            return Ok(postalCode);
        }
    }
}
