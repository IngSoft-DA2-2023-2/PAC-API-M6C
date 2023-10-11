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
        private StudentController _studentController;
        private Mock<IStudentLogic> _studentLogicMock;

        [TestInitialize]
        public void InitTest()
        {
            _studentLogicMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            _studentController = new StudentController(_studentLogicMock.Object);
        }

        [TestMethod]
        public void TestGetAllStudentsOk()
        {
            var students = new List<Student>
            {
                new Student { Id=1},
                new Student { Id=2}

            };

            _studentLogicMock.Setup(logic => logic.GetStudents()).Returns(students);

            var result = _studentController.Students() as ObjectResult;

            Assert.AreEqual(result, students);
        }


        [TestMethod]
        public void TestGetStudentOk()
        {
            Student studentToReturn = new Student()
            {
                Id = 1
        };

            _studentLogicMock.Setup(u => u.GetStudentById(It.IsAny<int>())).Returns(studentToReturn);
            var result = _studentController.GetStudent(1);
            _studentLogicMock.VerifyAll();
            Assert.AreEqual(studentToReturn, result);


        }

    }
}
 