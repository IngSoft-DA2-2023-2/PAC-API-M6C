namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Moq;
using Microsoft.AspNetCore.Mvc;

//using Microsoft.AspNetCore.Mvc;

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
        var createdResult = result as ActionResult<List<Student>>;
        Assert.AreEqual(expectedOutcome.Count, createdResult.Value.Count);
    }

    [TestMethod]
    public void GivenValidIdGetReturnsStudent()
    {
        var expectedOutcome = new Student() { Id = 5, Name = "Prueba" };
        mock.Setup(s => s.GetStudentById(5)).Returns(expectedOutcome);
        var result = studentController.GetStudentById(5);
        var createdResult = result as ActionResult<Student>;
        Assert.AreEqual(expectedOutcome, createdResult.Value);
    }

    [TestMethod]
    public void GivenInvalidIdGetReturnsNotFound()
    {
        Student? nullStudent = null;
        mock.Setup(s => s.GetStudentById(7)).Returns(nullUser);
        var result = studentController.GetStudentById(7);
        Assert.AreEqual(result.Value, null);
    }

    [TestMethod]
    public void GivenValidStudentItGetsCreated()
    {
        Student student = new Student() { Id = 3,Name = "Prueba" };
        mock.Setup(s => s.InsertStudents(student));
        var result = studentController.InsertStudents(student);
        var createdResult = result as OkResult;
        Assert.AreEqual(createdResult.StatusCode, 200);
    }
}