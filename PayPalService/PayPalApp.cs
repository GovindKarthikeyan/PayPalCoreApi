using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPalService
{
    public class PayPalApp
    {
		public void CallPayPal()
		{
			var client = new PayPalService.PayPalAPIAAInterfaceClient();
			//client.SetExpressCheckout();
		}
    }
}
