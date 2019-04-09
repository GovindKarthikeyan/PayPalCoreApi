using System;

namespace PayPalLegacyConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var credentials = new PayPalService.CustomSecurityHeaderType
			{
				Credentials = new PayPalService.UserIdPasswordType
				{
					Username = "karthik-business_api1.Lux.com",
					Password = "NKXWBHEMPVFJBK7Y",
					Signature = "Agx6Wbqn9pHtIsQ6kM0JlN.vyYeFAL8zsQX87GUPrhzPkju5VvSGp5td"
				}
			};

			SetExpressCheckOut(credentials);

			Console.WriteLine("Press enter key to exit...");
			Console.ReadLine();
		}

		static void SetExpressCheckOut(PayPalService.CustomSecurityHeaderType credentials)
		{
			var req = new PayPalService.SetExpressCheckoutReq
			{
				SetExpressCheckoutRequest = new PayPalService.SetExpressCheckoutRequestType
				{
					SetExpressCheckoutRequestDetails = new PayPalService.SetExpressCheckoutRequestDetailsType
					{
						ReturnURL = @"https://www.spirit.com/",
						CancelURL = @"https://www.spirit.com/",
						PaymentDetails = new[]
						{
							new PayPalService.PaymentDetailsType
							{
								OrderTotal = new PayPalService.BasicAmountType
								{
									currencyID = PayPalService.CurrencyCodeType.USD,
									Value = "100"
								},
								PaymentAction = PayPalService.PaymentActionCodeType.Order
							}
						},
						SolutionType = PayPalService.SolutionTypeType.Mark
					},
					Version = "100"
				}
			};

			try
			{
				using (var client = new PayPalService.PayPalAPIAAInterfaceClient())
				{
					var result = client.SetExpressCheckout(ref credentials, req);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		static void DoUATPExpressCheckoutPayment(PayPalService.CustomSecurityHeaderType credentials)
		{
			var req = new PayPalService.DoUATPExpressCheckoutPaymentReq
			{
				DoUATPExpressCheckoutPaymentRequest = new PayPalService.DoUATPExpressCheckoutPaymentRequestType
				{
					DoExpressCheckoutPaymentRequestDetails = new PayPalService.DoExpressCheckoutPaymentRequestDetailsType
					{
						Token = "",
						ClientID = "",
						PayerID = "",
						// etc.1111
					}
				}
			};
			try
			{
				using (var client = new PayPalService.PayPalAPIAAInterfaceClient())
				{
					var result = client.DoUATPExpressCheckoutPayment(ref credentials, req);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
