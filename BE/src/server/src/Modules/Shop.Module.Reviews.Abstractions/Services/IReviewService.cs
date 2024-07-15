using Shop.Module.Core.Models;
using Shop.Module.Reviews.Models;
using System.Threading.Tasks;

namespace Shop.Module.Reviews.Services
{
    public interface IReviewService
    {
        Task ReviewAutoGood(int entityId, EntityTypeWithId entityTypeId, int? sourceId, ReviewSourceType? sourceType);
    }
}
