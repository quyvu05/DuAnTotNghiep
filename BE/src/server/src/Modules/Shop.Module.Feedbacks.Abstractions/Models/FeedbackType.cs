using System.ComponentModel;

namespace Shop.Module.Feedbacks.Models
{
    public enum FeedbackType
    {
        [Description("Product-related")]
        Product = 0,
        [Description("Logistics-related")]
        Logistics = 1,
        [Description("Customer service")]
        Customer = 2,
        [Description("Promotional activities")]
        Discounts = 3,
        [Description("Functional anomaly")]
        Dysfunction = 4,
        [Description("Product Proposal")]
        ProductProposal = 5,
        [Description("Other")]
        Other = 6
    }
}
