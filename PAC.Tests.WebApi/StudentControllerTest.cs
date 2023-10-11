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
    }
}
