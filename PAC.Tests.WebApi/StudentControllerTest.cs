namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.IDataAccess;

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
        public void GetAllStudients()
        {
            List<Student> sutdients = new List<Student>();
            var repo = new Mock<IStudentsRepository<Student>>();
            repo.Setup(x => x.GetStudents()).Returns(sutdients);
            var logic = new Mock<IStudentLogic>();
            logic.Setup(x => x.GetStudents()).Returns(repo.Object.GetStudents());

            var controller = new StudentController(logic.Object);
            var result = controller.GetAllStudents();
        }
    }
}
