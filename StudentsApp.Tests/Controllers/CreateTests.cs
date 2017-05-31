using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsApp.Controllers;
using System;
using System.Web.Mvc;

namespace StudentsApp.Tests.Controllers
{
    [TestClass]
    public class CreateTests
    {

        [TestMethod()]
        public void CreatePageTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();
            var course = new Models.CourseList()
            {
                CourseId = 1111,
                StudentId = 2,
                StartDate = Convert.ToDateTime("01/08/2016"),
                EndDate = Convert.ToDateTime("10/08/2016")
            };
            // Act

            var result = controller.Create(course) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

    }
}
