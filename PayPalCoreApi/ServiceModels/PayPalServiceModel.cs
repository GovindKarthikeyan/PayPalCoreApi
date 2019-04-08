using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PayPalCoreApi.ServiceModels
{
	public class PayPalServiceModel
	{
		public string GetMessage()
		{
			var http = new HttpClient();
			return http.GetStringAsync(@"https://putsreq.com/xNBUFnVa9EDm50Jja0qn?name=KarthikG").Result; ;
		}

		public string SetExpressCheckOut()
		{
			// Live https://api-3t.paypal.com/2.0/
			// Sandbox https://api-3t.sandbox.paypal.com/2.0/

			var client = new PayPalService.PayPalServiceRef.PayPalAPIAAInterfaceClient();
			var header = new PayPalService.PayPalServiceRef.CustomSecurityHeaderType();
			var req = new PayPalService.PayPalServiceRef.SetExpressCheckoutReq();
			req.SetExpressCheckoutRequest = new PayPalService.PayPalServiceRef.SetExpressCheckoutRequestType();
			var x = client.SetExpressCheckoutAsync(header, req).Result;

			var http = new HttpClient();
			var response = http.GetAsync(@"https://api-3t.sandbox.paypal.com/2.0/").Result;
			return "7T132552335340332";
		}
	}
}
