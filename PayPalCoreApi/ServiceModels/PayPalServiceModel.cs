using PayPalService.PayPalService;
using System.ServiceModel;

namespace PayPalCoreApi.ServiceModels
{
	public class PayPalServiceModel
	{
		public string SetExpressCheckOut()
		{
			var req = new SetExpressCheckoutReq
			{
				SetExpressCheckoutRequest = new SetExpressCheckoutRequestType
				{
					SetExpressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType
					{
						ReturnURL = @"https://www.paypal.com/checkoutnow/error",
						CancelURL = @"https://www.paypal.com/checkoutnow/error",
						PaymentDetails = new[]
						{
							new PaymentDetailsType
							{
								OrderTotal = new BasicAmountType { currencyID = CurrencyCodeType.USD, Value = "100" },
								PaymentAction = PaymentActionCodeType.Order
							}
						},
						SolutionType = SolutionTypeType.Mark
					},
					Version = "100"
				}
			};

			var factory = new ChannelFactory<PayPalAPIAAInterface>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), new EndpointAddress("https://api-aa.sandbox.paypal.com/2.0/"));
			var proxy = factory.CreateChannel();
			var resp = proxy.SetExpressCheckoutAsync(new SetExpressCheckoutRequest
			{
				RequesterCredentials = GetHeaderCredentials(),
				SetExpressCheckoutReq = req
			}).Result;
			factory.Close();

			return resp?.SetExpressCheckoutResponse1?.Token ?? "";
		}

		public DoUATPExpressCheckoutPaymentResponse DoExpressCheckOutPaymentUATP(string Token, string PayerId)
		{
			var req = new DoUATPExpressCheckoutPaymentReq
			{
				DoUATPExpressCheckoutPaymentRequest = new DoUATPExpressCheckoutPaymentRequestType
				{
					DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType
					{
						Token = Token,
						PayerID = PayerId,
						PaymentDetails = new[] 
						{
							new PaymentDetailsType
							{
								OrderTotal = new BasicAmountType { currencyID = CurrencyCodeType.USD, Value = "100"},
								PaymentAction = PaymentActionCodeType.Order
							}
						},
					},
					Version = "100"
				}
			};

			var factory = new ChannelFactory<PayPalAPIAAInterface>(new BasicHttpBinding(BasicHttpSecurityMode.Transport),new EndpointAddress("https://api-aa.sandbox.paypal.com/2.0/"));
			var proxy = factory.CreateChannel();
			var resp = proxy.DoUATPExpressCheckoutPaymentAsync(
				new DoUATPExpressCheckoutPaymentRequest
				{
					RequesterCredentials = GetHeaderCredentials(),
					DoUATPExpressCheckoutPaymentReq = req
					
				}).Result;
			factory.Close();

			return resp;
		}

		private CustomSecurityHeaderType GetHeaderCredentials()
		{
			return new CustomSecurityHeaderType
			{
				Credentials = new UserIdPasswordType
				{
					Username = "karthik-business_api1.Lux.com",
					Password = "NKXWBHEMPVFJBK7Y",
					Signature = "Agx6Wbqn9pHtIsQ6kM0JlN.vyYeFAL8zsQX87GUPrhzPkju5VvSGp5td"
				}
			};
		}
	}
}
