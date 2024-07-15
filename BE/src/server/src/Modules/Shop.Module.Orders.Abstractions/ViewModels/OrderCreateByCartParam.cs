using System.ComponentModel.DataAnnotations;

namespace Shop.Module.Orders.ViewModels
{
    public class OrderCreateByCartParam
    {
        [Required]
        public int ShippingUserAddressId { get; set; }

        [StringLength(450)]
        public string OrderNote { get; set; }
    }
}
