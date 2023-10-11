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
            new Student { Id = 1, Name = "Pepe" },
            new Student { Id = 2, Name = "Juan"},
        };

            _studentLogicMock.Setup(logic => logic.GetStudents()).Returns(students);

            var Okresult = _studentController.GetStudents() as ObjectResult;
            var result = Okresult.Value as IEnumerable<Student>;

            Assert.AreEqual(students.Count(), result.Count());
        }

        [TestMethod]
        public void TestGetStudentByIdOk()
        {
            Student studentToReturn = new Student()
            {
                Id = 1,
                Name = "Julepe",

            };

            _studentLogicMock.Setup(u => u.GetStudentById(1)).Returns(studentToReturn);

            var result = _studentController.GetStudentById(1);
            var okResult = result as OkObjectResult;
            var student = okResult.Value as Student;

            _studentLogicMock.VerifyAll();
            Assert.IsTrue(student.Id == 1);
        }
    }
}
