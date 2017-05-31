using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace StudentsApp.Controllers.Tests
{
    [TestClass()]
    public class CourseListsControllerTests
    {
        
        [TestMethod()]
        public void IndexViewEqualIndexTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Index(null) as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod()]
        public void IndexModelNotNullIndexTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Index("") as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }


        [TestMethod()]
        public void CreatePageTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditPagelTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod()]
        public void EditIdNotFoundTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = (HttpStatusCodeResult)controller.Edit(-1);

            // Assert
            
            Assert.AreEqual(HttpStatusCode.BadRequest, result);
        }

        [TestMethod()]
        public void DeletePageTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Delete(null) as ViewResult;

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod()]
        public void DeleteIdNullTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Delete(null) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result);
        }

        [TestMethod()]
        public void DeleteCourseNotFoundTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = (HttpNotFoundResult)controller.Delete(-1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}