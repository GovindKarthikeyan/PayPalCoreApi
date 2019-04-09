using System.ServiceModel;

namespace PayPalCoreApi.ServiceModels
{
	public class PayPalServiceModel
	{
		public string SetExpressCheckOut()
		{
			var req = new PayPalService.PayPalService.SetExpressCheckoutReq
			{
				SetExpressCheckoutRequest = new PayPalService.PayPalService.SetExpressCheckoutRequestType
				{
					SetExpressCheckoutRequestDetails = new PayPalService.PayPalService.SetExpressCheckoutRequestDetailsType
					{
						ReturnURL = @"https://www.paypal.com/checkoutnow/error",
						CancelURL = @"https://www.paypal.com/checkoutnow/error",
						PaymentDetails = new[]
									{
							new PayPalService.PayPalService.PaymentDetailsType
							{
								OrderTotal = new PayPalService.PayPalService.BasicAmountType
								{
									currencyID = PayPalService.PayPalService.CurrencyCodeType.USD,
									Value = "100"
								},
								PaymentAction = PayPalService.PayPalService.PaymentActionCodeType.Order
							}
						},
						SolutionType = PayPalService.PayPalService.SolutionTypeType.Mark
					},
					Version = "100"
				}
			};
			var credentials = new PayPalService.PayPalService.CustomSecurityHeaderType
			{
				Credentials = new PayPalService.PayPalService.UserIdPasswordType
				{
					Username = "karthik-business_api1.Lux.com",
					Password = "NKXWBHEMPVFJBK7Y",
					Signature = "Agx6Wbqn9pHtIsQ6kM0JlN.vyYeFAL8zsQX87GUPrhzPkju5VvSGp5td"
				}
			};
			var binding = new BasicHttpBinding();
			binding.Security.Mode = BasicHttpSecurityMode.Transport;
			var endpoint = new EndpointAddress("https://api-aa.sandbox.paypal.com/2.0/");
			//var factory = new ChannelFactory<PayPalService.PayPalService.PayPalAPIAAInterface>("PayPalAPIAA", new EndpointAddress("https://api-aa.sandbox.paypal.com/2.0/"));
			var factory = new ChannelFactory<PayPalService.PayPalService.PayPalAPIAAInterface>(binding, endpoint);
			var p = factory.CreateChannel();
			
			var resp = p.SetExpressCheckoutAsync(new PayPalService.PayPalService.SetExpressCheckoutRequest
			{
				RequesterCredentials = credentials,
				SetExpressCheckoutReq = req
			}).Result;

			return resp?.SetExpressCheckoutResponse1?.Token?.Replace("EC-", "")?.Trim() ?? "";
		}

		public string DoExpressCheckOutPaymentUatp()
		{
			var req = new PayPalService.PayPalService.DoUATPExpressCheckoutPaymentReq
			{
				DoUATPExpressCheckoutPaymentRequest = new PayPalService.PayPalService.DoUATPExpressCheckoutPaymentRequestType
				{
					DoExpressCheckoutPaymentRequestDetails = new PayPalService.PayPalService.DoExpressCheckoutPaymentRequestDetailsType
					{
						Token = "",
						ClientID = "",
						PayerID = "",
						// etc.1111
					}
				}
			};
			var credentials = new PayPalService.PayPalService.CustomSecurityHeaderType
			{
				Credentials = new PayPalService.PayPalService.UserIdPasswordType
				{
					Username = "karthik-business_api1.Lux.com",
					Password = "NKXWBHEMPVFJBK7Y",
					Signature = "Agx6Wbqn9pHtIsQ6kM0JlN.vyYeFAL8zsQX87GUPrhzPkju5VvSGp5td"
				}
			};

			return "";
		}

		
	}
}
