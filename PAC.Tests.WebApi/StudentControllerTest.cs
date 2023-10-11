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
        [TestMethod]
        public void CanGetAllUsers_Ok()
        {
            var student = new Student()
            {
                Name = "Mateo"
            };

            var students = Enumerable.Repeat(student, 2).ToList();
            
            var studentService = new Mock<IStudentLogic>();
            studentService.Setup(service => service.GetStudents()).Returns(students);

            var studentController = new StudentController(studentService.Object);
            
            var result = studentController.GetStudents() as OkObjectResult;
            var results = result!.Value as List<Student>;

            CollectionAssert.AreEqual(students, results);
        }
        
        [TestMethod]
        public void CanGetUserById_Ok()
        {
            var student = new Student()
            {
                Name = "Mateo"
            };
            
            var studentService = new Mock<IStudentLogic>();
            studentService.Setup(service => service.GetStudentById(It.IsAny<int>()))
                .Returns(student);
            
            var studentController = new StudentController(studentService.Object);

            var result = studentController.GetStudentsById(1) as OkObjectResult;
            var studentResult = result!.Value as Student;

            Assert.AreEqual(student, studentResult);
        }
    }
}
