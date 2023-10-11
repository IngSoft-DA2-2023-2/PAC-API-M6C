using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PAC.Tests.WebApi
{
    [TestClass]
    public class StudentControllerTest
    {
        private Mock<IStudentLogic> _studentLogicMock;
        private StudentController _controller;

        [TestInitialize]
        public void InitTest()
        {
            _studentLogicMock = new Mock<IStudentLogic>();
            _controller = new StudentController(_studentLogicMock.Object);
        }

        [TestMethod]
        public void CanCreateController_Ok()
        {
            Assert.IsNotNull(_controller);
        }

        [TestMethod]
        public void CanGetAllStudents()
        {
            var studentList = new List<Student>
            {
                new Student() { Id = 1, Name = "Pablo" },
                new Student() { Id = 2, Name = "Julieta" },
                new Student() { Id = 3, Name = "Felipe" }
            };

            _studentLogicMock.Setup(service => service.GetStudents()).Returns(studentList);

            var result = _controller.GetAll() as OkObjectResult;
            var students = result.Value as List<Student>;

            Assert.AreEqual(students.Count, 3);
            CollectionAssert.Contains(students, studentList[0]);
        }

        [TestMethod]
        public void CanGetStudentById_Ok()
        {
            var studentList = new List<Student>
            {
                new Student() { Id = 1, Name = "Pablo" },
                new Student() { Id = 2, Name = "Julieta" },
                new Student() { Id = 3, Name = "Felipe" }
            };

            _studentLogicMock.Setup(service => service.GetStudentById(It.IsAny<int>()))
                   .Returns<int>(id => studentList.FirstOrDefault(b => b.Id == id));

            var result1 = _controller.GetById(1) as OkObjectResult;
            var student1 = result1.Value as Student;

            var result2 = _controller.GetById(2) as OkObjectResult;
            var student2 = result2.Value as Student;

            Assert.AreEqual(student1.Name, studentList[0].Name);
            Assert.AreEqual(student1.Id, studentList[0].Id);

            Assert.AreEqual(student2.Name, studentList[1].Name);
            Assert.AreEqual(student2.Id, studentList[1].Id);
        }

        [TestMethod]
        public void CanCreateStudent_Ok()
        {
            var student = new Student()
            {
                Id = 45,
                Name = "Pablo Emilio Escobar Gaviria",
            };

            var result = _controller.Create(student) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}
