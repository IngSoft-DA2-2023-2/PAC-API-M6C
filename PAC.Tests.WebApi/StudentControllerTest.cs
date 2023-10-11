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

        [TestMethod]
        public void GetStudentById_Ok()
        {
            var studentLogic = new Mock<IStudentLogic>();
            studentLogic.Setup(sl => sl.GetStudentById(1)).Returns(_mockStudent1);

            var studentController = new StudentController(studentLogic.Object);
            var result = studentController.GetStudentById(1) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(_mockStudent1, result.Value);
        }
        [TestMethod]
        public void CreateStudent_Ok()
        {
            var newStudent = new Student { Name = "Carlos" };

            var studentLogic = new Mock<IStudentLogic>();

            var studentController = new StudentController(studentLogic.Object);
            var result = studentController.InsertStudents(newStudent) as OkResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }
    }
}


