using Shop.Module.Orders.Models;
using System;

namespace Shop.Module.Orders.ViewModels
{
    public class OrderQueryResult
    {
        public int Id { get; set; }

        public string No { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int? ShippingAddressId { get; set; }

        public int? BillingAddressId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentType PaymentType { get; set; }

        public ShippingStatus? ShippingStatus { get; set; }

        public ShippingMethod ShippingMethod { get; set; }

        public decimal ShippingFeeAmount { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public decimal PaymentFeeAmount { get; set; }

        public DateTime? PaymentOn { get; set; }

        public decimal OrderTotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public string OrderNote { get; set; }

        public string AdminNote { get; set; }

		/// <summary>
		/// Transaction closed/transaction cancellation reason
		/// The reasons you can choose are:
		/// 1. Failure to pay on time
		/// 2. Buyer does not want to buy
		/// 3. Buyer information is incorrect, please bid again
		/// 4. Malicious buyer/companion troublemaker
		/// 5. Out of stock
		/// 6. Buyer bid the wrong item
		/// 7. Meet-up transaction in the same city
		/// ...
		/// </summary>
		public string CancelReason { get; set; }

        public DateTime? CancelOn { get; set; }

        public int CreatedById { get; set; }

        public int UpdatedById { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
