namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Intrinsics.X86;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        Student student1;
        Student student2;
        [TestInitialize]
        public void TestInit()
        {
            student1 = new Student()
            {
                Id = 1,
                Name = "Test",
            };
            student2 = new Student()
            {
                Id = 2,
                Name = "Test2",
            };
        }

        [TestMethod]
        public void GetAllStudentsOk()
        {
            var studentMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            StudentController controller = new StudentController(studentMock.Object);
            List<Student> students = new List<Student>()
            {
                student1,
                student2
            };
            studentMock.Setup(x => x.GetStudents()).Returns(students);
            var result = controller.GetStudents();
            var okResult = result as OkObjectResult;
            var modelOut = okResult.Value as List<Student>;

            studentMock.VerifyAll();

            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(modelOut);
        }
        [TestMethod]
        public void GetStudentByIdOk()
        {
            var studentMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            StudentController controller = new StudentController(studentMock.Object);
            studentMock.Setup(x => x.GetStudentById(1)).Returns(student1);
            var result = controller.GetStudentById(1);
            var okResult = result as OkObjectResult;
            var modelOut = okResult.Value as Student;

            studentMock.VerifyAll();

            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(modelOut);
        }
        [TestMethod]
        public void NewStudentOk()
        {
            var studentMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            StudentController controller = new StudentController(studentMock.Object);
            studentMock.Setup(x => x.InsertStudents(student1)).Verifiable();
            var result = controller.NewStudent(student1);
            var okResult = result as OkResult;

            studentMock.VerifyAll();

            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
