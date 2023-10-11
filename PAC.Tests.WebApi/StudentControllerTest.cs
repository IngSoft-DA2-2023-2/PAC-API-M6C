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
        [TestMethod]
        public void GetAllStudents()
        {
            //Arrange
            Student student = new Student()
            {
                Id = 1,
                Name = "test"
            };

            IEnumerable<Student> students = new List<Student>()
            {
                student
            };

            Mock<IStudentLogic> studentLogic = new Mock<IStudentLogic>();
            studentLogic.Setup(x => x.GetStudents()).Returns(students);

            StudentController studentController = new StudentController(studentLogic.Object);
            OkObjectResult expected = new OkObjectResult(new List<StudentsDTO>()
            {
                new StudentsDTO(students.First())
            });

            List<StudentsDTO> expectedStudents = (expected.Value as List<StudentsDTO>)!;

            //Act
            OkObjectResult result = (studentController.GetStudents() as OkObjectResult)!;
            Console.WriteLine(result.Value);
            List<StudentsDTO> objectResult = (result.Value as List<StudentsDTO>)!;

            //Assert
            studentLogic.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
                && expectedStudents.First().Name.Equals(objectResult.First().Name));
        }

        [TestMethod]
        public void GetStudentById()
        {
            //Arrange
            Student student = new Student()
            {
                Id = 1,
                Name = "test"
            };

            IEnumerable<Student> students = new List<Student>()
            {
                student
            };

            Mock<IStudentLogic> studentLogic = new Mock<IStudentLogic>();
            studentLogic.Setup(x => x.GetStudents()).Returns(students);

            StudentController studentController = new StudentController(studentLogic.Object);
            OkObjectResult expected = new OkObjectResult(new List<StudentsDTO>()
            {
                new StudentsDTO(students.First())
            });

            List<StudentsDTO> expectedStudents = (expected.Value as List<StudentsDTO>)!;

            //Act
            OkObjectResult result = (studentController.GetStudentById() as OkObjectResult)!;
            Console.WriteLine(result.Value);
            List<StudentsDTO> objectResult = (result.Value as List<StudentsDTO>)!;

            //Assert
            studentLogic.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
                          && expectedStudents.First().Name.Equals(objectResult.First().Name));
        }
    }
}
