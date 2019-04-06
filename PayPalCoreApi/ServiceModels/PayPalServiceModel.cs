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
	}
}
