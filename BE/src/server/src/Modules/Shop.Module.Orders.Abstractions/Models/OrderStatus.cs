using System.ComponentModel;

namespace Shop.Module.Orders.Models
{
	public enum OrderStatus
	{
		[Description("New order")]
		New = 0,

		[Description("Pending")]
		OnHold = 10,

		[Description("Pending payment")]
		PendingPayment = 20,

		[Description("Payment failed")]
		PaymentFailed = 25,

		[Description("Paid")]
		PaymentReceived = 30,

		[Description("Shipping")]
		Shipping = 40,

		[Description("Shipped")]
		Shipped = 50,

		[Description("Transaction successful")]
		Complete = 60,

		[Description("Transaction canceled")]
		Canceled = 70
	}
}