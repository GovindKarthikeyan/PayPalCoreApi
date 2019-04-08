using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPalCoreApi.ServiceModels;

namespace PayPalCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        // GET: api/Payment
        [HttpGet("setexpresscheckout")]
        public ActionResult Get()
        {
			var service = new PayPalServiceModel();
			return new JsonResult(service.SetExpressCheckOut());
		}

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Payment
        [HttpPost]
        public string Post([FromBody] string value)
        {
			var service = new PayPalServiceModel();
			return service.SetExpressCheckOut();
		}

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
