using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FeedbackReviewer.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace FeedbackReviewer.Services
{
    public class AssignmentsDataService : IAssignmentsDataService
    {
        public Assignment AddAssignment(Assignment assignment)
        {
            //The service owns the Guid for any new objects.
            assignment.AssignmentId = Guid.NewGuid();

            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"INSERT INTO [Assignments]([Id],[PerformanceReviewId],[EmployeeId]) VALUES(@Id,@PerformanceReviewId,@EmployeeId)";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = assignment.AssignmentId });
                    command.Parameters.Add(new SqlParameter("PerformanceReviewId", System.Data.SqlDbType.UniqueIdentifier) { Value = assignment.PerformanceReviewId });
                    command.Parameters.Add(new SqlParameter("EmployeeId", System.Data.SqlDbType.UniqueIdentifier) { Value = assignment.EmployeeId });

                    command.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return assignment;
        }

        public Assignment GetAssignment(Guid assignmentId)
        {
            Assignment assignment = null;
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"SELECT * FROM [Assignments] WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = assignmentId });
                    var myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        assignment = new Assignment()
                        {
                            AssignmentId = Guid.Parse(myReader["Id"].ToString()),
                            PerformanceReviewId = Guid.Parse(myReader["PerformanceReviewId"].ToString()),
                            EmployeeId = Guid.Parse(myReader["EmployeeId"].ToString()),
                        };
                    }
                }
                myConnection.Close();
            }
            return assignment;
        }

        public List<Assignment> GetEmployeesAssignments(Guid employeeId)
        {
            List<Assignment> assignments = new List<Assignment>();
            using (var myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackReviewerDB"].ConnectionString))
            {
                myConnection.Open();
                string sqlCommand = @"SELECT * FROM [Assignments] WHERE EmployeeId = @Id";
                using (SqlCommand command = new SqlCommand(sqlCommand, myConnection))
                {
                    command.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.UniqueIdentifier) { Value = employeeId });
                    var myReader = command.ExecuteReader();
                    while (myReader.Read())
                    {
                        var assignment = new Assignment()
                        {
                            AssignmentId = Guid.Parse(myReader["Id"].ToString()),
                            PerformanceReviewId = Guid.Parse(myReader["PerformanceReviewId"].ToString()),
                            EmployeeId = Guid.Parse(myReader["EmployeeId"].ToString()),
                        };
                        assignments.Add(assignment);
                    }
                }
                myConnection.Close();
            }
            return assignments;
        }
    }
}