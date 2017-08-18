using FeedbackReviewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FeedbackReviewer.Controllers
{
    [RoutePrefix("api/assignments")]
    public class AssignmentsController : ApiController
    {
        [Route("{assignmentId:Guid}")]
        [HttpGet]
        public Assignment Get(Guid assignmentId)
        {
            return new Assignment();
        }

        [Route("")]
        [HttpPost]
        public string Add(Assignment assignment)
        {
            return "ADDED Assignment";
        }
    }
}
