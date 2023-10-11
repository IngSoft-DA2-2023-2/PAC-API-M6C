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
        IStudentLogic studentLogicMock;
        Studentcontroller controller;
          
        [TestInitialize]
        public void InitTest()
        {
            studentLogicMock = new Mock<StudentLogic>();
            controller = new StudentController(studentLogicMock);
        }

        [TestMethod]
        public void getStudents()
        {
            IActionResult result = controller.getStudents();
            var okResult = result as OkObjectResult;
            var modelOut = okResult.Value as IEnumerable<Student>;

            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(modelOut);
        }

    }
}
