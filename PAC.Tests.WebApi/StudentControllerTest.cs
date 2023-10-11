using Microsoft.AspNetCore.Mvc;
using Moq;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI;


namespace Test.Controller
{
    [TestClass]
    public class StudentControllerTest
    {
        private readonly Student _mockStudent1 = new() { Id = 1, Name = "John" };
        private readonly Student _mockStudent2 = new() { Id = 2, Name = "Jane" };
        [TestMethod]
        public void GetAllStudents_Ok()
        {
            var students = new List<Student> { _mockStudent1, _mockStudent2 };

            var studentLogic = new Mock<IStudentLogic>();
            studentLogic.Setup(sl => sl.GetStudents()).Returns(students);

            var studentController = new StudentController(studentLogic.Object);
            var result = studentController.GetStudents() as OkObjectResult;

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(students, result.Value as List<Student>);
        }
    }
}


