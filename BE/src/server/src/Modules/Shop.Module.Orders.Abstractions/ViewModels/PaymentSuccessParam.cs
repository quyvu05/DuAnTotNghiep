using Shop.Module.Orders.Models;
using System;

namespace Shop.Module.Orders.ViewModels
{
    public class PaymentReceivedParam
    {
        public int? OrderId { get; set; }

        public string OrderNo { get; set; }

        public PaymentMethod? PaymentMethod { get; set; }

        public decimal? PaymentFeeAmount { get; set; }

        public DateTime? PaymentOn { get; set; }

        public string Note { get; set; }
    }
}
