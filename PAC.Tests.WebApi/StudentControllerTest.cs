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
        public void InitTest()
        {
        }

        [TestMethod]
        public void GetOkTest()
        {
            Student oneStudent = new Student();
            Student secondStudent = new Student();
            List<Student> students = new List<Student>();
            students.Add(oneStudent);
            students.Add(secondStudent);

            var studentServiceMock = new Mock<IStudentLogic>(MockBehavior.Strict);
            studentServiceMock.Setup(s => s.Get()).Returns(students);
            var stuentController = new StudentController(studentServiceMock.Object);

            var result = StudentController.Get();
            var okResult = result as OkObjectResult;
            var value = okResult.Value;
            IEnumerable<Student> valueEnumerable = value as IEnumerable<Student>;
            List<Student> studentList = valueEnumerable.ToList();
            studentServiceMock.VerifyAll();
            Assert.IsTrue(students.SequenceEqual(studentList));
        }
    }
}
