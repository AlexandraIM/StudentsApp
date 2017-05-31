using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsApp.Controllers.Tests
{
    [TestClass()]
    public class IndexTests
    {
       
        [TestMethod()]
        public void IndexViewEqualIndexTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Index(null) as ViewResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void IndexModelNotNullIndexTest()
        {
            // Arrange
            CourseListsController controller = new CourseListsController();

            // Act
            var result = controller.Index("Alex") as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }
    }
}