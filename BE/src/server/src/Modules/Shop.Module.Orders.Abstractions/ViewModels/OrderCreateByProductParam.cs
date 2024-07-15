using System.ComponentModel.DataAnnotations;

namespace Shop.Module.Orders.ViewModels
{
    public class OrderCreateByProductParam
    {
        [Required]
        public int ShippingUserAddressId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [StringLength(450)]
        public string OrderNote { get; set; }
    }
}
