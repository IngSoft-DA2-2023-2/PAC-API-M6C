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
        private readonly Mock<IStudentLogic> _studentLogicMock;
        private readonly StudentController _studentController;

        public UsuarioControllerTest()
        {
            _studentLogicMock = new Mock<IStudentLogic>();
            _studentController = new StudentController(_studentLogicMock.Object);
        }

        [TestMethod]
        public void Get_ReturnsStudents()
        {
            // Arrange
            var students = new List<Student>
        {
            new Student { Id = 1, Name = "Student 1" },
            new Student { Id = 2, Name = "Student 2" },
        };

            _studentLogicMock.Setup(x => x.GetStudents()).Returns(students);

            // Act
            var result = _studentController.Get() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var returnedStudents = result.Value as List<Student>;
            Assert.IsNotNull(returnedStudents);
            CollectionAssert.AreEqual(students, returnedStudents);
        }

        [TestMethod]
        public void Get_WithValidId_ReturnsStudent()
        {
            // Arrange
            var student = new Student { Id = 1, Name = "Student 1" };
            _studentLogicMock.Setup(x => x.GetStudentById(1)).Returns(student);

            // Act
            var result = _studentController.Get(1) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            var returnedStudent = result.Value as Student;
            Assert.IsNotNull(returnedStudent);
            Assert.AreEqual(student, returnedStudent);
        }

        [TestMethod]
        public void Get_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            _studentLogicMock.Setup(x => x.GetStudentById(1)).Returns((Student)null);

            // Act
            var result = _studentController.Get(1) as NotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Post_WithValidStudent_ReturnsOk()
        {
            // Arrange
            var student = new Student { Name = "New Student" };
            _studentLogicMock.Setup(x => x.InsertStudents(student));

            // Act
            var result = _studentController.Post(student, "authorizationHeader") as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Estudiante creado", result.Value);
        }

        [TestMethod]
        public void Post_WithInvalidStudent_ReturnsBadRequest()
        {
            // Arrange
            var invalidStudent = new Student(); // Missing required properties.
            _studentLogicMock.Setup(x => x.InsertStudents(invalidStudent)).Throws(new Exception("Invalid student data"));

            // Act
            var result = _studentController.Post(invalidStudent, "authorizationHeader") as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Invalid student data", result.Value);
        }
    }
}
