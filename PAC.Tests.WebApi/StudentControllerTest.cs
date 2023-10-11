namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;
using PAC.IDataAccess;
using PAC.BusinessLogic;
using System;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        private Mock<IStudentsRepository<Student>> mockStudentRepository;
        private IStudentLogic studentLogic;

        [TestInitialize]
        public void InitTest()
        {
            mockStudentRepository = new Mock<IStudentsRepository<Student>>();
            studentLogic = new StudentLogic(mockStudentRepository.Object);
        }

        [TestMethod]
        public void AddStudent_ShouldAddStudent()
        {
            var student = new Student();
            studentLogic.InsertStudents(student);
            mockStudentRepository.Verify(s => s.InsertStudents(student), Times.Once);
        }

        [TestMethod]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            var students = new List<Student>
            {
                new Student { Id = 0, Name = "Estudiante 1" },
                new Student { Id = 1, Name = "Estudiante 2" },
                new Student { Id = 2, Name = "Estudiante 3" },
            };
            mockStudentRepository.Setup(s => s.GetStudents()).Returns(students);

            var result = studentLogic.GetStudents();
            Assert.AreEqual(students, result);
        }

        [TestMethod]
        public void AddUser_GetById_ValidUser_ShouldCallUnitOfWorkAddAndSave()
        {
            var student = new Student { Id = 0, Name = "Estudiante 1" };
            mockStudentRepository.Setup(s => s.GetStudentById(0)).Returns(student);

            var result = studentLogic.GetStudentById(0);
            Assert.AreEqual(student, result);
        }
    }
}
