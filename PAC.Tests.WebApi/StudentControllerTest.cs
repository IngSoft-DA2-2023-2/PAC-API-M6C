namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.IDataAccess;
using PAC.BusinessLogic;
using Microsoft.AspNetCore.Http;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        private Mock<IStudentLogic> mockStudents;
        private StudentController studentController;

        [TestInitialize]
        public void InitTest()
        {
            mockStudents = new Mock<IStudentLogic>(MockBehavior.Strict);
            studentController = new StudentController(mockStudents.Object);
        }

        [TestMethod]
        public void GetStudents()
        {
            var expectedOutcome = new List<Student>();
            Student student = new Student()
            {
                Id = 1,
                Name = "Santiago"
            };
            expectedOutcome.Add(student);

            mockStudents.Setup(s => s.GetStudents()).Returns(expectedOutcome);
            var result = studentController.GetStudents();
            var createdResult = result as ActionResult<List<Student>>;
            Assert.AreEqual(expectedOutcome.Count, createdResult.Value.Count);
        }

        [TestMethod]
        public void GetStudentById()
        {
            var expectedOutcome = new Student()
            {
                Id = 1,
                Name = "Santiago"
            };

            mockStudents.Setup(s => s.GetStudentById(1)).Returns(expectedOutcome);
            var result = studentController.GetStudentById(1);
            var createdResult = result as ActionResult<Student>;
            Assert.AreEqual(expectedOutcome, createdResult.Value);
        }

        [TestMethod]
        public void InsertStudents()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["rol"] = "admin";
            studentController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            var student = new Student()
            {
                Id = 2,
                Name = "Santiago"
            };

            mockStudents.Setup(s => s.GetStudentById(2)).Returns(student);
            var result = studentController.InsertStudents(student);

            var get = studentController.GetStudentById(2);
            var createdResult = get as ActionResult<Student>;
            Assert.AreEqual(student, createdResult.Value);
        }
    }

    
}
