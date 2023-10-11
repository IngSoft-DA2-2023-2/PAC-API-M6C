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
        [TestInitialize]
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
            OkObjectResult expected = new OkObjectResult(new List<Student>()
            {
                students.First()
            });

            List<Student> expectedStudents = (expected.Value as List<Student>)!;

            //Act
            OkObjectResult result = (studentController.GetStudents() as OkObjectResult)!;
            Console.WriteLine(result.Value);
            List<Student> objectResult = (result.Value as List<Student>)!;

            //Assert
            studentLogic.VerifyAll();
            Assert.IsTrue(result.StatusCode.Equals(expected.StatusCode)
                && expectedStudents.First().Name.Equals(objectResult.First().Name));
        }
    }
}
