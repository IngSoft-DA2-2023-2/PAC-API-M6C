namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        private Mock<IStudentLogic> _logicMock;
        private StudentController _controller;

        private Student _testStudent1;
        private Student _testStudent2;
        private Student _testStudent3;

        [TestInitialize]
        public void InitTest()
        {
            _logicMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            _controller = new StudentController(_logicMock.Object);

            _testStudent1 = new Student() { Id = 1, Name = "Student 1" };
            _testStudent2 = new Student() { Id = 2, Name = "Student 2" };
            _testStudent3 = new Student() { Id = 3, Name = "Student 3" };
        }

        [TestMethod]
        public void GetAllStudents_Success()
        {
            List<Student> expectedStudents = new List<Student>()
            {
                _testStudent1,
                _testStudent2,
                _testStudent3,
            };
            _logicMock.Setup(s => s.GetStudents()).Returns(expectedStudents);

            var result = _controller.GetAllStudents();

            var createdResult = result as ActionResult<List<Student>>;
            for (int i = 0; i < expectedStudents.Count; i++)
            {
                Assert.AreEqual(expectedStudents[i], createdResult.Value[i]);
            }
        }

        [TestMethod]
        public void GetStudentsById_Success()
        {
            Student expectedStudent = _testStudent1;
            _logicMock.Setup(s => s.GetStudentById(expectedStudent.Id)).Returns(expectedStudent);

            var result = _controller.GetStudentById(expectedStudent.Id);

            var createdResult = result as ActionResult<Student>;
            Assert.AreEqual(expectedStudent, createdResult.Value);
        }

        [TestMethod]
        public void CreateStudent_Success()
        {
            _logicMock.Setup(s => s.InsertStudents(_testStudent1));

            var result = _controller.CreateStudent(_testStudent1);
            var createdResult = result as OkResult;
            Assert.AreEqual(createdResult.StatusCode, 200);
        }
    }
}
