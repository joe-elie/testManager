using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestManagerV2.Data;

namespace TestManager.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void CreateTest_saves_a_test_via_context()
        {
            var mockSet = new Mock<DbSet<TestManagerV2.Models.Test>>();

            var mockContext = new Mock<TestManagerV2Context>();
            mockContext.Setup(m => m.Test).Returns(mockSet.Object);

            var service = new TestService(mockContext.Object);
            service.AddTest("test name", "test description",
                "circuit name", 1, "environment", false);

            mockSet.Verify(m => m.Add(It.IsAny<TestManagerV2.Models.Test>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetAllTest()
        {
            var data = new List<TestManagerV2.Models.Test>
            {
                new TestManagerV2.Models.Test() { TestName = "1" },
                new TestManagerV2.Models.Test() { TestName = "2" },
                new TestManagerV2.Models.Test() { TestName = "3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TestManagerV2.Models.Test>>();
            mockSet.As<IQueryable<TestManagerV2.Models.Test>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TestManagerV2.Models.Test>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TestManagerV2.Models.Test>>().Setup(m => m.ElementType).Returns(data.ElementType);


            var mockContext = new Mock<TestManagerV2Context>();
            mockContext.Setup(c => c.Test).Returns(mockSet.Object);

            var service = new TestService(mockContext.Object);
            var blogs = service.GetAllTests();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("1", blogs[0].TestName);
            Assert.AreEqual("2", blogs[1].TestName);
            Assert.AreEqual("3", blogs[2].TestName);
        }
    }
}
