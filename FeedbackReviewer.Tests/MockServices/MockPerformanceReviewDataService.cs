using FeedbackReviewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackReviewer.Models;

namespace FeedbackReviewer.Tests.MockServices
{
    class MockPerformanceReviewDataService : IPerformanceReviewDataService
    {
        private Dictionary<Guid, PerformanceReview> _performanceReviews;

        public MockPerformanceReviewDataService()
        {
            _performanceReviews = new Dictionary<Guid, PerformanceReview>();
        }

        public PerformanceReview AddPerformanceReview(PerformanceReview performanceReview)
        {
            _performanceReviews.Add(performanceReview.PerformanceReviewId, performanceReview);
            return _performanceReviews[performanceReview.PerformanceReviewId];
        }

        public List<PerformanceReview> GetAllPerformanceReviews()
        {
            var returnlist = new List<PerformanceReview>();
            foreach (var key in _performanceReviews.Keys)
            {
                returnlist.Add(_performanceReviews[key]);
            }
            return returnlist;
        }

        public PerformanceReview GetPerformanceReview(Guid performanceReviewId)
        {
            return _performanceReviews[performanceReviewId];
        }

        public PerformanceReview UpdatePerformanceReview(Guid performanceReviewId, PerformanceReview performanceReview)
        {
            _performanceReviews[performanceReviewId] = performanceReview;
            return _performanceReviews[performanceReviewId];
        }
    }
}
