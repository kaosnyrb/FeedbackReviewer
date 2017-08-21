using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackReviewer.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace FeedbackReviewer.Services
{
    public class PerformanceReviewDataService : IPerformanceReviewDataService
    {
        public PerformanceReview AddPerformanceReview(PerformanceReview performanceReview)
        {
            //The service owns the Guid for any new objects.
            performanceReview.PerformanceReviewId = Guid.NewGuid();
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"INSERT INTO [PerformanceReviews]([Id],[EmployeeId],[Feedback]) VALUES(@Id,@EmployeeId,@Feedback)";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = performanceReview.PerformanceReviewId });
                    command.Parameters.Add(new SqlParameter("EmployeeId", System.Data.SqlDbType.UniqueIdentifier) { Value = performanceReview.EmployeeId });
                    command.Parameters.Add(new SqlParameter("Feedback", System.Data.SqlDbType.NVarChar) { Value = performanceReview.Feedback });
                    command.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return performanceReview;
        }

        public List<PerformanceReview> GetAllPerformanceReviews()
        {
            var performanceReviewList = new List<PerformanceReview>();
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"SELECT * FROM [PerformanceReviews]";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    var myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        PerformanceReview temp = new PerformanceReview()
                        {
                            PerformanceReviewId = Guid.Parse(myReader["Id"].ToString()),
                            EmployeeId = Guid.Parse(myReader["EmployeeId"].ToString()),
                            Feedback = myReader["Feedback"].ToString(),
                        };
                        performanceReviewList.Add(temp);
                    }
                }
                myConnection.Close();
            }
            return performanceReviewList;
        }

        public PerformanceReview GetPerformanceReview(Guid performanceReviewId)
        {
            PerformanceReview performanceReview = null;
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"SELECT * FROM [PerformanceReviews] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = performanceReviewId });
                    var myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        performanceReview = new PerformanceReview()
                        {
                            PerformanceReviewId = Guid.Parse(myReader["Id"].ToString()),
                            EmployeeId = Guid.Parse(myReader["EmployeeId"].ToString()),
                            Feedback = myReader["Feedback"].ToString(),
                        };
                    }
                }
                myConnection.Close();
            }
            return performanceReview;
        }

        public PerformanceReview UpdatePerformanceReview(Guid performanceReviewId, string feedback)
        {
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"UPDATE [PerformanceReviews] SET [Feedback] = @Feedback WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = performanceReviewId });
                    command.Parameters.Add(new SqlParameter("Feedback", System.Data.SqlDbType.NVarChar) { Value = feedback });

                    command.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return GetPerformanceReview(performanceReviewId);
        }
    }
}