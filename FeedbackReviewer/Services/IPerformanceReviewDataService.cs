using FeedbackReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackReviewer.Services
{
    public interface IPerformanceReviewDataService
    {
        List<PerformanceReview> GetAllPerformanceReviews();

        PerformanceReview GetPerformanceReview(Guid performanceReviewId);

        PerformanceReview AddPerformanceReview(PerformanceReview performanceReview);

        PerformanceReview UpdatePerformanceReview(Guid performanceReviewId, PerformanceReview performanceReview);
    }
}
