using System.ComponentModel;

namespace Shop.Module.Reviews.Models
{
    public enum RatingLevel
    {
        [Description("Bad")]
        Bad = 1,
        [Description("Medium")]
        Medium = 3,
        [Description("Positive")]
        Positive = 5
    }
}
