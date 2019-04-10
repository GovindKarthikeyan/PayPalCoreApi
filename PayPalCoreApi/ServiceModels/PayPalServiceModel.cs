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
			var factory = new ChannelFactory<PayPalService.PayPalService.PayPalAPIAAInterface>(
								new BasicHttpBinding(BasicHttpSecurityMode.Transport), 
								new EndpointAddress("https://api-aa.sandbox.paypal.com/2.0/"));
			var proxy = factory.CreateChannel();
			var resp = proxy.SetExpressCheckoutAsync(new PayPalService.PayPalService.SetExpressCheckoutRequest
			{
				RequesterCredentials = credentials,
				SetExpressCheckoutReq = req
			}).Result;
			
			return resp?.SetExpressCheckoutResponse1?.Token ?? "";
		}

		public PayPalService.PayPalService.DoUATPExpressCheckoutPaymentResponse DoExpressCheckOutPaymentUATP(string Token, string PayerId)
		{
			var req = new PayPalService.PayPalService.DoUATPExpressCheckoutPaymentReq
			{
				DoUATPExpressCheckoutPaymentRequest = new PayPalService.PayPalService.DoUATPExpressCheckoutPaymentRequestType
				{
					DoExpressCheckoutPaymentRequestDetails = new PayPalService.PayPalService.DoExpressCheckoutPaymentRequestDetailsType
					{
						Token = Token,
						PayerID = PayerId,
						PaymentDetails = new[] 
						{
							new PayPalService.PayPalService.PaymentDetailsType
							{
								OrderTotal = new PayPalService.PayPalService.BasicAmountType
								{
									currencyID= PayPalService.PayPalService.CurrencyCodeType.USD,
									Value="100"
								},
								PaymentAction = PayPalService.PayPalService.PaymentActionCodeType.Sale
							}
						},
						
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
			var factory = new ChannelFactory<PayPalService.PayPalService.PayPalAPIAAInterface>(
										new BasicHttpBinding(BasicHttpSecurityMode.Transport),
										new EndpointAddress("https://api-aa.sandbox.paypal.com/2.0/"));
			var proxy = factory.CreateChannel();
			var resp = proxy.DoUATPExpressCheckoutPaymentAsync(
				new PayPalService.PayPalService.DoUATPExpressCheckoutPaymentRequest
				{
					RequesterCredentials = credentials,
					DoUATPExpressCheckoutPaymentReq = req
					
				}).Result;

			return resp;
		}

		
	}
}
