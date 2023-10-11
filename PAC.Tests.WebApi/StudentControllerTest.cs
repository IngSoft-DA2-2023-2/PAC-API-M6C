namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Moq;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    private Mock<IStudentLogic> mock;
    private StudentController studentController;

    [TestInitialize]
    public void TestInitialize()
    {
        mock = new Mock<IStudentLogic>(MockBehavior.Strict);
        studentController = new StudentController(mock.Object);
    }

    [TestMethod]
    public void GetAllStudentsWorksCorrectly()
    {
        var expectedOutcome = new List<Student>();
        mock.Setup(s => s.GetStudents()).Returns(expectedOutcome);
        var result = studentController.GetStudents();
        var resultList = result.ToList();
        Assert.AreEqual(expectedOutcome.Count, resultList.Count);
    }

    [TestMethod]
    public void GivenValidIdGetReturnsStudent()
    {
        var expectedOutcome = new Student() { Id = 5, Name = "Prueba" };
        mock.Setup(s => s.GetStudentById(5)).Returns(expectedOutcome);
        var result = studentController.GetStudentById(5);
        Assert.AreEqual(expectedOutcome, result);
    }

    [TestMethod]
    public void GivenValidStudentItGetsCreated()
    {
        Student student = new Student() { Id = 3,Name = "Prueba" };
        mock.Setup(s => s.InsertStudents(student));
        mock.Setup(s => s.GetStudentById(3)).Returns(student);
        studentController.InsertStudents(student);
        Assert.IsNotNull(studentController.GetStudentById(3));
    }
}