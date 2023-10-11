using PAC.WebAPI.Models;

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
        private Student _student;
        private Mock<IStudentLogic> _studentService;

        [TestInitialize]
        public void InitTest()
        {
            _student  = new Student()
            {
                Name = "Mateo"
            };

            _studentService = new Mock<IStudentLogic>();
        }
        
        [TestMethod]
        public void CanGetAllUsers_Ok()
        {
            var students = Enumerable.Repeat(_student, 2).ToList();
            
            _studentService.Setup(service => service.GetStudents()).Returns(students);

            var studentController = new StudentController(_studentService.Object);
            
            var result = studentController.GetStudents() as OkObjectResult;
            var results = result!.Value as List<Student>;

            CollectionAssert.AreEqual(students, results);
        }
        
        [TestMethod]
        public void CanGetUserById_Ok()
        {
            _studentService.Setup(service => service.GetStudentById(It.IsAny<int>()))
                .Returns(_student);
            
            var studentController = new StudentController(_studentService.Object);

            var result = studentController.GetStudentsById(1) as OkObjectResult;
            var studentResult = result!.Value as Student;

            Assert.AreEqual(_student, studentResult);
        }
        
        [TestMethod]
        public void CanCreateStudent_Ok()
        {
            var studentController = new StudentController(_studentService.Object);
            var newStudent = new StudentCreateModel()
            {
                Name = "Mate",
            };

            var result = studentController.InsertStudent(newStudent) as OkResult;

            Assert.AreEqual(200, result!.StatusCode);
        }
    }
}
