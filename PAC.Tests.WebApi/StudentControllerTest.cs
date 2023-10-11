namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.BusinessLogic;
using PAC.DataAccess;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        [TestInitialize]
        public void InitTest()
        {
        }

        [TestMethod]
        public void CanCreateController_Ok()
        {
            var studentLogicMock = new Mock<IStudentLogic>();
            StudentController controller = new StudentController(studentLogicMock.Object);
            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void CanGetAllStudents()
        {
            var studentLogicMock = new Mock<IStudentLogic>();
            var studentList = new List<Student>
            {
                new Student() { Id = 1, Name = "Pablo" },
                new Student() { Id = 2, Name = "Julieta" },
                new Student() { Id = 3, Name = "Felipe" }
            };
            studentLogicMock.Setup(service => service.GetStudents()).Returns(studentList);
            StudentController controller = new StudentController(studentLogicMock.Object);


            var result = controller.GetAll() as OkObjectResult;
            var students = result.Value as List<Student>;

            Assert.AreEqual(students.Count, 3);
            CollectionAssert.Contains(students, studentList[0]);
        }

    }
}
