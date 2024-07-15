using Shop.Module.Feedbacks.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Module.Feedbacks.ViewModels
{
    public class FeedbackAddParam
    {
        [StringLength(450)]
        public string Contact { get; set; }

        [StringLength(450)]
        [Required(ErrorMessage = "Please enter content, and the content length cannot exceed 450")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please select a feedback type")]
        public FeedbackType? Type { get; set; }
    }
}
