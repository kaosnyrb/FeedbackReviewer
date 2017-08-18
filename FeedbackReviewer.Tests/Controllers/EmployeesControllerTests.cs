using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeedbackReviewer.Controllers;

namespace FeedbackReviewer.Tests.Controllers
{
    [TestClass]
    public class EmployeesControllerTests
    {

        [TestMethod]
        public void GetAllEmployeesReturnsEmployeeList()
        {
            var target = new EmployeesController()
            {
                _employeeDataService = new MockServices.MockEmployeeDataService()
            };
            var userGuid = Guid.NewGuid();
            target.Post(new Models.Employee { EmployeeId = userGuid, Name = "Fred" });
            var results = target.GetEmployees();

            Assert.IsTrue(results[0].EmployeeId == userGuid);
            Assert.IsTrue(results[0].Name == "Fred");
        }

        [TestMethod]
        public void GetEmployeeReturnsEmployee()
        {
            var target = new EmployeesController()
            {
                _employeeDataService = new MockServices.MockEmployeeDataService()
            };
            var userGuid = Guid.NewGuid();
            target.Post(new Models.Employee { EmployeeId = userGuid, Name = "Fred" });
            var results = target.Get(userGuid);

            Assert.IsTrue(results.EmployeeId == userGuid);
            Assert.IsTrue(results.Name == "Fred");
        }

        [TestMethod]
        public void PutEmployeeChangesEmployee()
        {
            var target = new EmployeesController()
            {
                _employeeDataService = new MockServices.MockEmployeeDataService()
            };
            var userGuid = Guid.NewGuid();
            target.Post(new Models.Employee { EmployeeId = userGuid, Name = "Fred" });

            var newName = "Paul";
            target.Put(userGuid, new Models.Employee { EmployeeId = userGuid, Name = newName });

            var results = target.Get(userGuid);
            Assert.IsTrue(results.EmployeeId == userGuid);
            Assert.IsTrue(results.Name == newName);
        }

        [TestMethod]
        public void DeleteingEmployeeRemovesThem()
        {
            var target = new EmployeesController()
            {
                _employeeDataService = new MockServices.MockEmployeeDataService()
            };
            var userGuid = Guid.NewGuid();
            target.Post(new Models.Employee { EmployeeId = userGuid, Name = "Fred" });

            target.Delete(userGuid);

            bool threwException = false;
            try
            {
                var results = target.Get(userGuid);
            }
            catch (Exception e)
            {
                threwException = true;
            }
            Assert.IsTrue(threwException);

        }
    }
}
