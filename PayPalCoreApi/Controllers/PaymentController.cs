using Microsoft.AspNetCore.Mvc;
using PayPalCoreApi.ServiceModels;

namespace PayPalCoreApi.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
		// GET: api/Payment/setexpresscheckout
		[HttpGet("setexpresscheckout")]
        public ActionResult Get()
        {
			var service = new PayPalServiceModel();
			return new JsonResult(service.SetExpressCheckOut());
		}

		// POST: api/Payment/approve
		[HttpPost("approve")]
		public ActionResult Post([FromBody] ApproveRequest req)
		{
			var uatpResp = new PayPalServiceModel().DoExpressCheckOutPaymentUATP(req.TokenId, req.PayerId);
			return new JsonResult(uatpResp);
		}

		// GET: api/Payment/5
		[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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

	public class ApproveRequest
	{
		public string TokenId { get; set; }
		public string PayerId { get; set; }
	}
}
