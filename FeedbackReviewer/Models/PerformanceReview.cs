﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackReviewer.Models
{
    public class PerformanceReview
    {
        public Guid PerformanceReviewId { get; set; }

        public Guid EmployeeId { get; set; }

        public string Feedback { get; set; }
    }
}