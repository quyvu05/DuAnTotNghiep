﻿using Shop.Module.Core.Models;
using Shop.Module.Reviews.Models;

namespace Shop.Module.Reviews.ViewModels
{
    public class AdminReviewQueryParam
    {
        public int? EntityId { get; set; }

        public EntityTypeWithId? EntityTypeId { get; set; }

        public ReviewStatus? Status { get; set; }

        public bool? IsMedia { get; set; }

        public int? Rating { get; set; }
    }
}
