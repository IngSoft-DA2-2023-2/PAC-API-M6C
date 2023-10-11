namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.IDataAccess;
using Castle.Components.DictionaryAdapter.Xml;

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
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetStudentById()
        {
            Student student = new Student();
            var repo = new Mock<IStudentsRepository<Student>>();
            repo.Setup(x => x.GetStudentById(It.IsAny<int>())).Returns(student);
            var logic = new Mock<IStudentLogic>();
            logic.Setup(x => x.GetStudentById(It.IsAny<int>())).Returns(repo.Object.GetStudentById(It.IsAny<int>()));

            var controller = new StudentController(logic.Object);
            var result = controller.GetStudentById(1);
            Assert.AreEqual(student, result);

        }

        [TestMethod]
        public void CreateAStudent()
        {
            List<Student> sutdients = new List<Student>();
            var repo = new Mock<IStudentsRepository<Student>>();
            repo.Setup(x => x.InsertStudents(It.IsAny<Student>())).Callback((Student newSudent) => sutdients.Add(newSudent));
            var logic = new Mock<IStudentLogic>();
            logic.Setup(x => x.InsertStudents(It.IsAny<Student>())).Callback((Student newSudent) => repo.Object.InsertStudents(newSudent));

            var controller = new StudentController(logic.Object);
            Student aStudent = new Student();
            controller.AddStudent(aStudent);
            Assert.IsTrue(sutdients.Count > 0);
        }
    }
}
