using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SendController : ApiController
    {
        private HW1 db = new HW1();

        [HttpPost]
        [Route("api/send/formdata")]
        public IHttpActionResult SendFormData([FromBody] FormData formData)
        {
            if (formData == null)
            {

                return Ok(new { StatusCode="404", msg=formData });
            }

            db.FormDatas.Add(formData);
            db.SaveChanges();



            // 在這裡處理接收到的表單數據
            // 例如，將數據保存到數據庫中
            return Ok("Form data received successfully.");
        }
    }
}
