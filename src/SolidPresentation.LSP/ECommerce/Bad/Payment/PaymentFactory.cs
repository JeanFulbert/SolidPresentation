namespace SolidPresentation.LSP.Bad.Payment
{
	using System;

	public class PaymentFactory
	{
		public static PaymentBase GetPaymentService(PaymentServiceType serviceType)
		{
			switch (serviceType)
			{
			case PaymentServiceType.PayPal:
				return new PayPalPayment();
			case PaymentServiceType.WorldPay:
				return new WorldPayPayment();
			default:
				throw new NotImplementedException("No such service.");
			}
		}
	}
}
