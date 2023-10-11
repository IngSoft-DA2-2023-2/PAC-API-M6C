using Microsoft.EntityFrameworkCore.Query.Internal;
using PAC.BusinessLogic;
using PAC.IDataAccess;

namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public void TestGetAllStudents()
        {
            var repo = new Mock<IStudentsRepository<StudentLogic>>();
            //enumerable en lista es lo que devolveria el setUp
            repo.Setup(x => x.GetStudents()).Returns();
            var logic = new Mock<IStudentLogic>();
            logic.Setup(x => x.GetStudents()).Returns(repo.Object.GetStudents());

            var userController = new StudentController(logic.Object);
            var result = userController.GetAllStudents();

            repo.VerifyAll();
            logic.VerifyAll();

            Assert.IsNotNull(result);
        }
    }
}
